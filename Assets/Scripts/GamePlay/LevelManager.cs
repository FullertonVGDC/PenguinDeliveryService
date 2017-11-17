using System.Collections;
using System.Collections.Generic;
using System.IO;
using GlobalVar;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    #region Data Member
    public GameObject WinText;

    public List<GameObject> platformPrefab;
    public GameObject platformContainer;
    public static LevelManager _instance;

    EnvBluePrint bluePrint;
    #endregion

    #region Getter Setter
    #endregion

    #region Built - in Method

    public void Awake () {
        if (_instance == null) {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        bluePrint = new EnvBluePrint ();
        SetupLevel (bluePrint);
    }

    // Update is called once per frame
    void Update () {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     SaveMockData();
        // }
    }
    #endregion
    #region Public Method

    public void ReachDestination (string destination) {
        switch (destination) {
            case "CheckPoint":
                WinText.GetComponent<Text> ().text = "Check Point reached!";
                WinText.GetComponent<Text> ().color = Color.red;
                WinText.SetActive (true);
                break;
            case "EndLevelZone":
                LevelComplete ();
                break;
            default:
                break;
        }
    }
    #endregion
    #region Private Method
    private void LevelComplete () {
        WinText.SetActive (true);
        //pause the player movement?
    }

    private void SaveMockData () {
        Debug.Log ("Write database");
        foreach (Transform platform in platformContainer.transform) {

            EnvObject temp = new EnvObject (platform.GetComponent<ObjectType> ().Type, platform.position, platform.rotation, platform.localScale);
            bluePrint.ListObject.Add (temp);
        }
        string path = "Assets/StreamingAssets/test.json";
        string json = JsonUtility.ToJson (bluePrint);
        StreamWriter writer = new StreamWriter (path, true);
        writer.Write (json);
        writer.Close ();
    }

    private void SetupLevel (EnvBluePrint newLevel) {
        string path = "Assets/StreamingAssets/test.json";
        StreamReader reader = new StreamReader (path);
        // Debug.Log(reader.ReadToEnd());
        string json = reader.ReadToEnd ();
        Debug.Log (json);
        bluePrint = JsonUtility.FromJson<EnvBluePrint> (json);

        foreach (var envObject in bluePrint.ListObject) {
            MakePlatform (envObject);
        }
        // add enemy
        // set starting location
        // set End location.
    }

    private void MakePlatform (EnvObject platForm) {

        GameObject temp = Instantiate (platformPrefab[platForm.type], platForm.location, platForm.rotation, platformContainer.transform) as GameObject;
        temp.transform.localScale = platForm.scale;
    }
    #endregion

}