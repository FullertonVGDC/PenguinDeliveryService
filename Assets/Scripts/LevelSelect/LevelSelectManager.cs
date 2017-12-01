using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelSelectManager : MonoBehaviour
{
       // go to the level // scene
    public void _GotoLevel(){
        SceneManager.LoadScene("GamePlayScene");
    }
}


