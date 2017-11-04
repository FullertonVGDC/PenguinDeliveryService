using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalVar;
using System.IO;

public class EnvironmentManager : MonoBehaviour
{

    public List<GameObject> platformPrefab;
    public GameObject platformContainer;

    EnvBluePrint bluePrint;
    // Use this for initialization
    void Start()
    {
        bluePrint = new EnvBluePrint();
        SetupLevel(bluePrint);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     SaveMockData();
        // }
    }

    private void SaveMockData()
    {
        foreach (Transform platform in platformContainer.transform)
        {

            EnvObject temp = new EnvObject(true, platform.position);
            bluePrint.ListObject.Add(temp);
        }
        string path = "Assets/StreamingAssets/test.json";
        string json = JsonUtility.ToJson(bluePrint);
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(json);
        writer.Close();
    }

    private void SetupLevel(EnvBluePrint newLevel)
    {
        string path = "Assets/StreamingAssets/test.json";
        StreamReader reader = new StreamReader(path);
        // Debug.Log(reader.ReadToEnd());
        string json = reader.ReadToEnd();
        bluePrint = JsonUtility.FromJson<EnvBluePrint>(json);
        Debug.Log(json);
        foreach (var envObject in bluePrint.ListObject)
        {
            MakePlatform(envObject);
        }
        // add enemy
        // set starting location
        // set End location.
    }

    private void MakePlatform(EnvObject platForm)
    {
        GameObject temp = Instantiate(platformPrefab[0], platForm.location, Quaternion.identity, platformContainer.transform) as GameObject;
    }
}
