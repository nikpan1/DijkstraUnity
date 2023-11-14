using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawPaths : MonoBehaviour
{

   [Serializable] 
    public struct lines {
        public Transform start;
        public Transform end;
    }

    List<lines> conns = new List<lines>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
