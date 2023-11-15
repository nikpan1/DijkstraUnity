using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Node : MonoBehaviour
{
    [Serializable]
    public class ls
    {
        public ls(Transform _transform, List<Transform> connections)
        {
            obj = _transform;
            connected = connections;
        }
        public Transform obj;
        public List<Transform> connected = new List<Transform>();
    }

    public static List<ls> allNodes = new List<ls>();
    public string label = "";

    [SerializeField] public List<Transform> connections = new List<Transform>();

    // the distances between connected nodes can be backed into the data later on
    private List<float> distances = new List<float>();

    // Start is called before the first frame update
    void Start() {
        
        foreach (Transform tr in connections) {
            float dist = Vector3.Distance(tr.position, this.transform.position);
            distances.Add(dist);


            Node scriptNode = tr.GetComponent<Node>();

            // Check if the script component exists
            if (scriptNode == null) Debug.LogError("some node doesn't have a Node script.");

            if (!scriptNode.connections.Contains(this.transform)) {
                scriptNode.connections.Add(this.transform);
                scriptNode.distances.Add(dist);
            }

        }

        ls inst = new ls(this.transform, connections);      // huh
        allNodes.Add(inst);
    }
}
