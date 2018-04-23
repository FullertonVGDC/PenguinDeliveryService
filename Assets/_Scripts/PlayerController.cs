using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
	#region Data Member
	
	// bool dead = false;
	bool isOnGround = false;
	//int current_hp = 100;
	//int damage;
	//int hp;
	public AudioClip[] sounds;
	public AudioSource instrument;
	public bool isDoubleJump = false;
	//public Collider2D playerCollider;
	public float jumpForce = 700;
	// public float slidespeed = 3;
	public float walkspeed = 10;
	public GameObject playerObject;
	
	Rigidbody2D rigid;
	Vector3 startingPosition; // If we are too far underwater we will teleport player to starting position.

    Animator pegu;

	#endregion


	#region Getter Setter
	#endregion


	#region Built - in Method

	void Start() {
		rigid = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the script and store it in rb
        pegu = GetComponent<Animator>();

		//playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();

		// hp = current_hp;

		// startingPosition = transform.position;
		
		// damage = 0;

	}

	void Update() {
		// if (hp < 0) {
		// 	respawn();
		// }


		Walk();
		//jump (press twice to double jump) with sound effect
		Jump();

		if (rigid.velocity.y > 0) {
			Debug.Log("pass through");
			//note: ground tiles labelled PassThru are the only ones that can be jumped through with below code
			Physics2D.IgnoreLayerCollision(11, 12, true);
		}
		//if player falls from jumping, player can land on the platform instead of falling through
		else {
			Physics2D.IgnoreLayerCollision(11, 12, false);
		}

		//slide (duck down and move left or right simultaneously) with momentum


		//walk with sound effect
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
			// playsound(0);
		}

		// check if your character fell off the platform
		if( transform.position.y < -20) {
			respawn();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) { 
		if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("PassThru")){
			isOnGround = true;
		}

		//when player lands on a platform designating the end of a level
		if (collision.gameObject.CompareTag("LevelEnd")) {
			//show new sprite "Level Complete" text on screen
			LevelManager._instance.ReachDestination(collision.gameObject.name); //just need tagged name of the gameObject
			isOnGround = true;
			Debug.Log("You reached the end of the level");
			// playsound(2);
		}
		
		if (collision.gameObject.CompareTag("Enemy")){
			respawn();
		}
	}

	private void OnTriggerEnter(Collider collision) {
		
	}

	#endregion
	#region Public Method
	#endregion
	#region Private Method

	private void Walk() {
        
		float movement = Input.GetAxis("Horizontal") * walkspeed;
        bool pressed = Input.GetButton("Horizontal");
		rigid.velocity = new Vector3(movement, rigid.velocity.y, 0);
        pegu.SetBool("run", pressed);
	}

	private void Jump() {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (isOnGround) {
				isOnGround = false;
				isDoubleJump = true; //Pegu can dbljump if he's on ground
				rigid.AddForce(new Vector3(0, jumpForce, 0)); // Adds 100 force straight up, might need tweaking on that number
				playsound(0);
			}
			if (isDoubleJump) {
				isDoubleJump = false; //2 jumps only
				rigid.AddForce(new Vector3(0, jumpForce, 0)); // Adds 100 force straight up, might need tweaking on that number
				playsound(0);
			}
		}
	}

	private void respawn() {
		Vector3 temp = transform.position; // copy to an auxiliary variable...
		temp.x = -1.64f; // modify the component you want in the variable...
		temp.y = 1.04f; 
		transform.position = temp; // and save the modified value
		// transform.position = startingPosition; // and save the modified value

		// hp = current_hp;
	}

	private void playsound(int index) {
		instrument.clip = sounds[index];
		instrument.Play();
	}

	#endregion

	


}