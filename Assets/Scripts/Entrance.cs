using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour {

    public string LevelEntrance;
    public int level;
    public Animator trans;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("load");
            trans.SetTrigger("transition");
            LevelSelectManager._instance.currentLevel = level;
         //   SceneManager.LoadScene(LevelEntrance);
        }
    }

}

