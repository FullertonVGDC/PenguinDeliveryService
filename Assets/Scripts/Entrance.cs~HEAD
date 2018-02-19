using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{

    public string LevelEntrance;
    public int level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager._instance.currentLevel = level;
            //   SceneManager.LoadScene(LevelEntrance);
        }
    }

}

