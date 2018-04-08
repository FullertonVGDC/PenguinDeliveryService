using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelDesignManager))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();
        //var valTotal = GameObject.Find("LevelDesignManager");
        //valTotal.max
        //Debug.Log(valTotal);
        LevelDesignManager man = target as LevelDesignManager;
        var totalLevels= man.MapFiles.Length;
        GUILayout.Label("Levels: " + "current Level" +" / " + totalLevels.ToString());
        // Level int for level 
        // Get data for map files

        LevelDesignManager myScript = (LevelDesignManager)target;
        if (GUILayout.Button("Save Map"))
        {
            myScript.MapBuilder();
        }

        else if (GUILayout.Button("Load Next Level"))
        {
            myScript.LoadNextLevel();
        }

    }
    
}
