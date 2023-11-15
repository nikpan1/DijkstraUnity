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
        DrawAllLines();
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

    static public void DrawAllLines()
    {
        if (conns.Count == 0) ;
        createConnectionMatrix();
        
        foreach (lines line in conns)
        {
            Debug.DrawLine(line.start.position, line.end.position, Color.red, 15.0f);
        }
    }

    static public void DrawPath(List<Node> path)
    {
        Node next, previous;

        for(int i = 1; i < path.Count; i ++)
        {
            Vector3 v1 = new Vector3(path[i].transform.position.x, 0.1f, path[i].transform.position.y);
            Vector3 v2 = new Vector3(path[i - 1].transform.position.x, 0.1f, path[i - 1].transform.position.y);
            
            Debug.DrawLine(path[i].transform.position, path[i - 1].transform.position, Color.green, 15.0f);
        }
    }
}
