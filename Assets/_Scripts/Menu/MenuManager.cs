using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void _MenuButton(int type){
        switch (type)
        {
            case 0:
                Application.Quit();
                break;
            case 1:
                SceneManager.LoadScene("LevelOneScene");
                break;
            default:
                break;
        }
        
	}
    
}
