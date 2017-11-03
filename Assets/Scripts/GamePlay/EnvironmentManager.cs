using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalVar;
using System.IO;

public class EnvironmentManager : MonoBehaviour
{

    public GameObject platformPrefab;
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

            EnvObject temp = new EnvObject(true, platform);
            bluePrint.ListObject.Add(temp);
        }
        string path = "Assets/StreamingAssets/test.json";
        string json = JsonUtility.ToJson(bluePrint);
        StreamWriter writer = new StreamWriter(path, true);
        Debug.Log(json);
        writer.Write(json);
        writer.Close();
    }

    private void SetupLevel(EnvBluePrint newLevel)
    {
        string path = "Assets/StreamingAssets/test.json";
        StreamReader reader = new StreamReader(path);
        // Debug.Log(reader.ReadToEnd());
        bluePrint = JsonUtility.FromJson<EnvBluePrint>(reader.ReadToEnd());

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
        GameObject temp = Instantiate(platformPrefab, platForm.location.position,
        platForm.location.rotation, platformContainer.transform);

    }
}
