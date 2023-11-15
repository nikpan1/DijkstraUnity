using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class DebugControls : Editor
{
    int radius = 100;
    int nodeNumber = 15;
    public override void OnInspectorGUI()
    {
        EditorGUILayout.IntField("Radius", radius);
        EditorGUILayout.IntField("Node Number", nodeNumber);
        if (GUILayout.Button("Generate Map"))
        {
            MapGenerator generator = (MapGenerator)target;
            generator.Regenerate(radius, nodeNumber);
        }
    }
}
