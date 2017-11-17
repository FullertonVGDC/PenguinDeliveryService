using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelSelectManager : MonoBehaviour
{
    // envirtoment objexct
    // Use this for initialization
    // Test out
    List<enviromentObject> myObject;
    void Start(){
        MapBuilder();
    }
    public void MapBuilder(){
        myObject = new List<enviromentObject>();
        Debug.Log("..saving");
        
        string path = "Assets/StreamingAssets/text.json";
        var writeJson = new StreamWriter(path);
   
        // loop through the hieracrch 
        foreach (Transform child in transform) {
            myObject.Add(new enviromentObject(true, child));
        }
        string json = JsonUtility.ToJson(myObject);
        Debug.Log(json);
        Debug.Log(myObject);

        writeJson.Close();
    }

    // go to the level // scene
    public void _GotoLevel(){
        SceneManager.LoadScene("GamePlayScene");
    }
}

public class enviromentObject {
    public bool isPassThrough;
    public Transform location;
    public enviromentObject(bool isPass, Transform trans){
        isPassThrough = isPass;
        location = trans;
    }
}
// look to chart. need to pass Enviro objects through this before we cast to json


