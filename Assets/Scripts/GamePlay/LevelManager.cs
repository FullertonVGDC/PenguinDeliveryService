using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject WinText;

    public static LevelManager _instance;

    public void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    public void ReachDestination(string destination)
    {
        switch (destination)
        {
            case "CheckPoint":
                WinText.GetComponent<Text>().text = "Check Point reached!";
                WinText.GetComponent<Text>().color = Color.red;
                WinText.SetActive(true);
                break;
            case "EndLevelZone":
                LevelComplete();
                break;
            default:
                break;
        }
    }

    private void LevelComplete()
    {
        WinText.SetActive(true);
        //pause the player movement?
    }
}
