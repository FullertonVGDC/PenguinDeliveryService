using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private bool dirRight = true;
	public float speed = 3.0f;
	private SpriteRenderer mySpriteRenderer;

	private void Awake() {
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
  
	// Update is called once per frame
	void Update () {
		if (dirRight) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			mySpriteRenderer.flipX = true;
		}
		else {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
			mySpriteRenderer.flipX = false;
		}
		
		if(transform.position.x >= 4.0f) {
			dirRight = false;
		}
		
		if(transform.position.x <= -4) {
			dirRight = true;
		}
	}

	// void Attack() {
	//
	// }
}
