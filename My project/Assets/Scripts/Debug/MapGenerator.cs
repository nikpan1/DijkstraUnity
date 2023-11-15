using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject nodePrefab;
    private List<GameObject> nodes = new List<GameObject>();

    private Transform GetRandomNode()
    {
        return nodes[(int)Random.Range(0, nodes.Count)].GetComponent<Transform>();
    }

    public void Regenerate(int radius, int nodeNumber)
    {
        if (nodePrefab != null) Debug.Log("jest");
        

        // spawning of new maps can be optimzed by reusing
        // already created instances, but there is no need for it :)
        foreach (GameObject oldNode in nodes) Destroy(oldNode);
        nodes = new List<GameObject>();

        // creating nodes with random positions
        for (int i = 0; i < nodeNumber; i ++) {
            GameObject newNode = Instantiate(nodePrefab);
            newNode.transform.position = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
            nodes.Add(newNode);
        }

        // creating random connections
        // in avg nodeNumber/2 + 1 connections foreach node
        int connectionsNumber = 0;
        foreach (GameObject node in nodes) {
            connectionsNumber = Random.Range(0, (int)((nodeNumber / 2) + 1));
            Node nodeSC = node.GetComponent<Node>();
            
            int i = 0;
            while (i <= connectionsNumber)
            {
                Transform randomNode = GetRandomNode();
                if (!nodeSC.connections.Contains(randomNode))
                {
                    i++;
                    nodeSC.connections.Add(randomNode);
                }
            }
                
        }


        // static allNodes


    }
}
