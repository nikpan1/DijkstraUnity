using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject nodePrefab;

    public void Regenerate(int radius, int nodeNumber)
    {
        Debug.Log("eo!");
        if (nodePrefab != null) Debug.Log("jest");

        GameObject newNode = Instantiate(nodePrefab);

        // random adding

    }
}
