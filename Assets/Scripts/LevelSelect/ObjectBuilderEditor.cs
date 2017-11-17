using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelSelectManager))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        LevelSelectManager myScript = (LevelSelectManager)target;
        if (GUILayout.Button("Save Map"))
        {
            myScript.MapBuilder();
        }
    }
}