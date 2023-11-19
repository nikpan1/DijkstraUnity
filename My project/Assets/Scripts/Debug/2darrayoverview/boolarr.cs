using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class boolarr : MonoBehaviour
{
    [Serializable] public struct line
    {
        List<bool> l;
    }

    public List<line> your2DBoolArray = new List<line>();
    [SerializeField]
    //public List<List<bool>> your2DBoolArray = new List<List<bool>>();


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
