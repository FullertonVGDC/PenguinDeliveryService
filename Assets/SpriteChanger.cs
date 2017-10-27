using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    private SpriteRenderer mySpriteRenderer;
    // Use this for initialization

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
  
	private void Update () {
       
        if (mySpriteRenderer != null)
        {
            //if left key is pressed
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // flip the sprite
                mySpriteRenderer.flipX = true;
            }
            //if right key is pressed
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // flip the sprite
                mySpriteRenderer.flipX = false;
            }
            //if down key is pressed
        }
    }
}
