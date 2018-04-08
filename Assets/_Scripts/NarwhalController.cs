using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarwhalController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		startingY = transform.position.y;

	}
	
	private bool goingUP = true;
	public float speed = 5;
	private SpriteRenderer mySpriteRenderer;
	private float startingY;

	private void Awake() {
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
  
	// Update is called once per frame
	void Update () {
		
		if (goingUP) {
			transform.Translate (Vector2.up * speed * Time.deltaTime);
		}
		else {
			transform.Translate (-Vector2.up * speed * Time.deltaTime);		
		}
		
		if(startingY - transform.position.y >= 0) { // 
			goingUP = true;
		}
		
		if(startingY - transform.position.y <= -12) {  // 0 - 12 = -12
			goingUP = false; 
		}
	}

	// void Attack() {
	//
	// }
}
