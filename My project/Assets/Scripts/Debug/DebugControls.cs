using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class DebugControls : Editor
{

    public override void OnInspectorGUI()
    {
        MapGenerator generator = (MapGenerator)target;

        generator.radius = EditorGUILayout.IntField("Radius", generator.radius);
        generator.nodeNumber = EditorGUILayout.IntField("Node Number", generator.nodeNumber);
        if (GUILayout.Button("Generate Map"))
        {
            generator.Regenerate();
        }
        if (GUILayout.Button("Draw Lines"))
        {
            DrawPaths.DrawAllLines();
        }
        if (GUILayout.Button("Get Shortest Path"))
        {
            //DijkstraPathFinding alg = new DijkstraPathFinding(Node.allNodes[0].obj, Node.allNodes[Node.allNodes.Count - 1].obj);
            //var path = alg.FindPath();
            List<Node> path = new List<Node>();
            path.Add(Node.allNodes[0].obj);
            path.Add(Node.allNodes[1].obj);
            path.Add(Node.allNodes[2].obj);
            path.Add(Node.allNodes[3].obj);
            path.Add(Node.allNodes[4].obj);
            path.Add(Node.allNodes[5].obj);
            DrawPaths.DrawPath(path);
        }
    }
}
