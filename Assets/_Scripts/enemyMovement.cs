using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		startingX = transform.position.x;
	}

	private bool dirRight = true;
	public float speed = 3;
	private SpriteRenderer mySpriteRenderer;
	private float startingX;

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
		
		if(startingX - transform.position.x < 0) { 
			dirRight = false;
		}
		
		if(startingX - transform.position.x > 12) {
			dirRight = true;
		}
	}

	// void Attack() {
	//
	// }
}
