using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Node : MonoBehaviour
{
    [Serializable]
    public class ls
    {
        public Node obj;
        public List<Node> connected = new List<Node>();
        public ls(Node _transform, List<Node> connections)
        {
            obj = _transform;
            connected = connections;
        }
    }

    // connection matrix
    // @TODO do przerobienia na tablicę 2d indexów
    public static List<ls> allNodes = new List<ls>();
    public string label = "";

    [SerializeField] public List<Node> connections = new List<Node>();

    // the distances between connected nodes can be backed into the data later on
    public List<float> distances = new List<float>();

    // Start is called before the first frame update
    void Start() {
        foreach (var tr in connections) {
            float dist = Vector3.Distance(tr.transform.position, this.transform.position);
            distances.Add(dist);

            Node scriptNode = tr.GetComponent<Node>();

            // Check if the script component exists
            if (scriptNode == null) Debug.LogError("Some node doesn't have a Node script.");

            if (!scriptNode.connections.Contains(this)) {
                scriptNode.connections.Add(this);
                scriptNode.distances.Add(dist);
            }
        }

        ls inst = new ls(this, connections);      // huh
        allNodes.Add(inst);
    }
}
