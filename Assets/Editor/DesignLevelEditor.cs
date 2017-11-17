using System.Collections;
using UnityEditor;
using UnityEngine;

public class DesignLevelEditor : EditorWindow

{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    [MenuItem ("Tool/DesignLevelEditor")]
    public static void ShowWindow () {
        EditorWindow.GetWindow (typeof (DesignLevelEditor));
    }
    void OnGUI () {
        // GUILayout.Box (new Rect (0, 0, Screen.width, Screen.height), "This is a box");
        GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField ("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle ("Toggle", myBool);
        myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup ();
    }
}