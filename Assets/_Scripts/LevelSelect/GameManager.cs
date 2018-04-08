using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;
    public int currentLevel;
    public Animator animator;

    private void Awake () {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad (this);
        } else {
            Destroy (gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene ().name == "LevelSelectScene") {
            ControlLevelSelectSenece ();
        }
    }

    private void ControlLevelSelectSenece () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            Debug.Log ("select level " + currentLevel);
            animator.SetTrigger ("transition");
        }
    }

    public void _GotoLevel () {
        SceneManager.LoadScene ("GamePlayScene");
    }
}