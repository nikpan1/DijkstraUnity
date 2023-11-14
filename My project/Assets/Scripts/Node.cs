using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public string label = "";

    [SerializeField] public List<Transform> connections = new List<Transform>();

    // the distances between connected nodes can be backed into the data later on
    public List<float> distances = new List<float>();

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
