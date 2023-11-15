using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class MapGenerator : MonoBehaviour
{
    private GameObject nodePrefab;
    private List<Node> nodes = new List<Node>();

    public int radius = 50;
    public int nodeNumber = 30;

    private void Generate()
    {
        // creating random connections
        // in avg max nodeNumber/3 connections for each node
        int connectionsNumber = 0;
        foreach (var node in nodes)
        {
            connectionsNumber = Random.Range(0, (int)((nodeNumber / 3)));
            Node nodeSC = node.GetComponent<Node>();
            
            int i = nodeSC.connections.Count;
            while (i <= connectionsNumber)
            {
                Node randomNode = GetRandomNode();
                if (!nodeSC.connections.Contains(randomNode))
                {
                    nodeSC.connections.Add(randomNode);
                    randomNode.GetComponent<Node>().connections.Add(nodeSC);
                    i++;
                }
            }

            Node.ls inst = new Node.ls(node, node.GetComponent<Node>().connections);
            Node.allNodes.Add(inst);
        }
    }

    private Node GetRandomNode()
    {
        return nodes[(int)Random.Range(0, nodes.Count)];
    }

    public void Regenerate()
    {
        // @TODO jak to powinno być zrobione huh
        if (nodePrefab == null) nodePrefab = this.GetComponent<kurwaprefabholderdzienki>().prefab;
        

        // spawning of new maps can be optimzed by reusing
        // already created instances, but there is no need for it :)
        foreach (var oldNode in nodes) DestroyImmediate(oldNode);
        nodes = new List<Node>();
        Node.allNodes.Clear();

        // creating nodes with random positions
        for (int i = 0; i < nodeNumber; i ++) {
            GameObject newNode = Instantiate(nodePrefab);
            newNode.transform.position = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
            nodes.Add(newNode.GetComponent<Node>());
        }

        Generate();
    }
}
