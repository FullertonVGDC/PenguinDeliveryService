using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using GlobalVar;


public class LevelDesignManager : MonoBehaviour {
    // envirtoment objexct
    // Use this for initialization
    // Test out
    List<EnviromentObject> myObject;

    private EnvBluePrint bluePrint;
    public string[] MapFiles;

    public void MapBuilder() {
        myObject = new List<EnviromentObject>();

        ObjectType[] listObject = FindObjectsOfType(typeof(ObjectType)) as ObjectType[];
        Debug.Log(listObject.Length);
        foreach (ObjectType Object in listObject)
        {
            Debug.Log(Object.name);
        }

        /*
         write the data to a specific level 
         */
        string path = "Assets/StreamingAssets/text.json";
        var writeJson = new StreamWriter(path);

        // loop through the hieracrch 
        //foreach (Transform child in transform)
        //{
        //    Debug.Log("..saving");
        //    myObject.Add(new EnviromentObject(true, child));
        //}
        //string json = JsonUtility.ToJson(myObject);
        //Debug.Log(json);
        //Debug.Log(myObject);

        // Save map based off of Json Load

        writeJson.Close();
    }
    public void LoadNextLevel()
        {
        //Loop through to load level
        // Using text in Map Files
        // Load level based of text input

        }


    }

    public class EnviromentObject {
        public bool isPassThrough;
        public Transform location;
        public EnviromentObject(bool isPass, Transform trans)
        {
            isPassThrough = isPass;
            location = trans;
        }
}