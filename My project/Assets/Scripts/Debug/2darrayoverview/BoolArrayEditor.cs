using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(boolarr))]
public class BoolArrayEditor : Editor
{
    public SerializedProperty matrixArray;

    private void OnEnable()
    {
        // Get a reference to the serialized property of your 2x2 array
        matrixArray = serializedObject.FindProperty("your2DBoolArray"); // Replace yourMatrixArray with the actual variable name
    }

    public override void OnInspectorGUI()
    {
        // Update the serialized object
        serializedObject.Update();

        // Display the 2x2 matrix preview
        DisplayMatrixPreview();

        // Apply changes to the serialized object
        serializedObject.ApplyModifiedProperties();
    }

    private void DisplayMatrixPreview()
    {
        // Assuming your matrixArray is a 2x2 array
        EditorGUILayout.LabelField("Matrix Preview");
        Debug.Log(matrixArray);
        EditorGUILayout.BeginVertical();

        for (int i = 0; i < matrixArray.arraySize; i ++)
        {
            Debug.Log(matrixArray.arraySize);
            EditorGUILayout.BeginHorizontal();
            DrawMatrixElement(i);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndVertical();
    }

    private void DrawMatrixElement(int index)
    {
        if (index < matrixArray.arraySize)
        {
            SerializedProperty element = matrixArray.GetArrayElementAtIndex(index);
            EditorGUILayout.PropertyField(element, GUIContent.none);
        }
    }
}
