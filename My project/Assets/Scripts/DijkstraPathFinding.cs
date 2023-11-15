using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraPathFinding
{
    [SerializeField] private Node start;
    [SerializeField] private Node end;

    private List<Node> d_nodes= new List<Node>();
    private List<float> d_values = new List<float>();

    private List<Node> visited = new List<Node>();

    public DijkstraPathFinding(Node _start, Node _end)
    {
        start = _start;
        end = _end;
    }

    private void Start()        // @TODO do wyjebania
    {
        foreach (var node in Node.allNodes)
        {
            d_nodes.Add(node.obj);
            d_values.Add(0);
        }
    }

    int MinIndex(List<float> distances)
    {
        float min = distances[0];
        foreach (var dist in distances)
        {
            if (min > dist)
            {
                min = dist;
            }
        }

        return distances.IndexOf(min);
    }

    void visit(Node node, List<Node> path, float distance)
    {
        visited.Add(node);
        if(d_values[d_nodes.IndexOf(node)] > distance)
        {
            d_values[d_nodes.IndexOf(node)] = distance;
        }


        for (int i = 0; i < node.connections.Count; i++)
        {
            var cp_path = path;
            cp_path.Add(node.connections[i]);
            visit(node.connections[i], cp_path, distance + node.distances[i]);
        }
    }

    public List<Node> FindPath()
    {
        List<Node> path = new List<Node>();
        visited = new List<Node>();

        path.Add(start);
        visit(start, path, 0);
        

        return path;
    }
}
