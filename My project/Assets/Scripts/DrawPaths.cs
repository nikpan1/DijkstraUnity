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

    public List<lines> conns = new List<lines>();



    // Start is called before the first frame update
    void Start()
    {
        conns = new List<lines>();
        List<Transform> checked_conn = new List<Transform>();

        foreach (Node.ls node in Node.allNodes)
        {
            foreach (Transform conn in node.connected)
            {
                if (checked_conn.Contains(conn)) continue;
                lines line = new lines(node.obj, conn);
                conns.Add(line);

            }
        }

        Debug.Log("eo2");
        foreach (lines line in conns)
        {
            Debug.DrawLine(line.start.position, line.end.position, Color.red, 10.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
