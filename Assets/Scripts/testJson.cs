using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class testJson : MonoBehaviour
{
    List<environmentObject> myObject;
    // Use this for initialization
    void Start()
    {

        string json = JsonUtility.ToJson(myObject);


        string path = "Assets/Resources/StreamingAssets/test.txt";


        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(json);
        writer.Close();

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        json = reader.ReadToEnd();
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

class environmentObject
{

}
