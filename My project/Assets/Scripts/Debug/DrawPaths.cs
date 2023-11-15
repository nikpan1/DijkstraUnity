using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawPaths : MonoBehaviour
{
    [Serializable]
    public struct lines
    {
        public lines(Transform _start, Transform _end)
        {
            start = _start;
            end = _end;
        }

        public Transform start;
        public Transform end;
    }

    
    static List<lines> conns = new List<lines>();


    private void Start()
    {
        DrawLines();
    }

    static private void createConnectionMatrix()
    {
        conns = new List<lines>();
        List<Node> checked_conn = new List<Node>();

        foreach (var node in Node.allNodes)
        {
            foreach (var conn in node.connected)
            {
                if (checked_conn.Contains(conn)) continue;
                lines line = new lines(node.obj.transform, conn.transform);
                conns.Add(line);

            }
        }

    }

    static public void DrawLines()
    {
        if (conns.Count == 0) createConnectionMatrix();
        
        foreach (lines line in conns)
        {
            Debug.DrawLine(line.start.position, line.end.position, Color.red, 15.0f);
        }
    }
}
