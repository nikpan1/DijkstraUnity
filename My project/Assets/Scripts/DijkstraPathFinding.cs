using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraPathFinding : MonoBehaviour
{
    [SerializeField] private Node start;
    [SerializeField] private Node end;

    private List<Node> d_nodes= new List<Node>();
    private List<float> d_values = new List<float>();

    private List<Node> visited = new List<Node>();


    private void Start()
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
        Node minN;
        // float minVal = distanceList.Min();
        // int index = distanceList.IndexOf(minVal);

        var a = node.distances;
        for (int i = 0; i < node.connections.Count; i++)
        {
            //if(map)
        }
    }

    List<Node> FindPath()
    {
        List<Node> path = new List<Node>();
        visited = new List<Node>();

        visit(start, path, 0);
        

        return path;
    }
}
