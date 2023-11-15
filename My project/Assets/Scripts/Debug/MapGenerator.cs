using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class MapGenerator : MonoBehaviour
{
    private GameObject nodePrefab;
    private List<GameObject> nodes = new List<GameObject>();

    public int radius = 50;
    public int nodeNumber = 30;

    private void Generate()
    {
        // creating random connections
        // in avg max nodeNumber/3 connections for each node
        int connectionsNumber = 0;
        foreach (GameObject node in nodes)
        {
            connectionsNumber = Random.Range(0, (int)((nodeNumber / 3)));
            Node nodeSC = node.GetComponent<Node>();

            int i = nodeSC.connections.Count;
            while (i <= connectionsNumber)
            {
                Transform randomNode = GetRandomNode();
                if (!nodeSC.connections.Contains(randomNode))
                {
                    nodeSC.connections.Add(randomNode);
                    randomNode.GetComponent<Node>().connections.Add(nodeSC.GetComponent<Transform>());
                    i++;
                }
            }

            Node.ls inst = new Node.ls(node.transform, node.GetComponent<Node>().connections);
            Node.allNodes.Add(inst);
        }
    }

    private Transform GetRandomNode()
    {
        return nodes[(int)Random.Range(0, nodes.Count)].GetComponent<Transform>();
    }

    public void Regenerate()
    {
        if (nodePrefab == null) nodePrefab = this.GetComponent<kurwaprefabholderdzienki>().prefab;
        

        // spawning of new maps can be optimzed by reusing
        // already created instances, but there is no need for it :)
        foreach (GameObject oldNode in nodes) DestroyImmediate(oldNode);
        nodes = new List<GameObject>();
        Node.allNodes.Clear();

        // creating nodes with random positions
        for (int i = 0; i < nodeNumber; i ++) {
            GameObject newNode = Instantiate(nodePrefab);
            newNode.transform.position = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
            nodes.Add(newNode);
        }

        Generate();
    }
}
