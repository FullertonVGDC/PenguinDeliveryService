using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
	#region Data Member
	
	// bool dead = false;
	// public float slidespeed = 3;
	//int current_hp = 100;
	//int damage;
	//int hp;
	//public Collider2D playerCollider;
	bool isOnGround = false;
	public AudioClip[] sounds;
	public AudioSource instrument;
	public bool isDoubleJump = true;
	public float jumpForce = 20; //changed to 20 for sane jumping. This should be the default value in Editor
	public float walkspeed = 10;
	public GameObject playerObject;

	public bool hasDash = false;
	bool dashing;
	public int dashTimer = 15;
	int dashCooldown = 60;
	int dashLockDir;
	public int dashForce = 100;
	int lastDir;

	Rigidbody2D rigid;
	Vector3 startingPosition; // If we are too far underwater we will teleport player to starting position.
	private SpriteRenderer mySpriteRenderer;
	Animator pegu;

	#endregion


	#region Getter Setter
	#endregion


	#region Built - in Method

	void Start() {
		rigid = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the script and store it in rb
		pegu = GetComponent<Animator>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();

		//playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
		// hp = current_hp;
		// startingPosition = transform.position;
		// damage = 0;

	}
		

	void Update() {
		spriteChanger();
		// if (hp < 0) {
		//  respawn();
		// }
		Walk();
		Jump();	 //jump (press twice to double jump) with sound effect
		Dash();

		if (rigid.velocity.y > 0) {
			Debug.Log("pass through");
			//note: ground tiles labelled PassThru are the only ones that can be jumped through with below code
			Physics2D.IgnoreLayerCollision(11, 12, true);
		}
		else { //if player falls from jumping, player can land on the platform instead of falling through
			Physics2D.IgnoreLayerCollision(11, 12, false);
		}

		//walk with sound effects
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
			// playsound(0);
		}

		// check if your character fell off the platform
		if( transform.position.y < -20) {
			respawn();
		}

		if (dashTimer > 0) {
			dashTimer--;
		}
		if (dashCooldown > 0) {
			dashCooldown--;
		}
		if (dashTimer == 0) {
			dashing = false;
		}
		if (dashCooldown == 0 && isOnGround && !hasDash) {
			hasDash = true;
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
			if (isDoubleJump) {
				isDoubleJump = false;
				rigid.velocity = new Vector2(0, jumpForce); // an equal jump velocity is added on every jump
				playsound(0);
			}
			if (isOnGround) {
				isOnGround = false;
				isDoubleJump = true;
				rigid.velocity = new Vector2(0, jumpForce);
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
		dashTimer = 0;
		dashCooldown = 0;
		dashing = false;
		hasDash = true;
	}

	private void Dash() {//dash in the direction you are facing
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			if (hasDash) {
				dashing = true;
				dashTimer = 15;
				dashCooldown = 60;
				hasDash = false;
				dashLockDir = lastDir;
			}
		}
		if (dashing) {
			rigid.AddForce(new Vector3(dashTimer * dashTimer * dashForce * lastDir, 0, 0));
		}
	}

	private void playsound(int index) {
		instrument.clip = sounds[index];
		instrument.Play();
	}

	private void spriteChanger() { // grabbed from spriteChanger.cs
		if (mySpriteRenderer != null) {
			//if left key is pressed
			if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {
				// flip the sprite
				mySpriteRenderer.flipX = true;
				lastDir = -1;
			}
			//if right key is pressed
			else if (Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
				// flip the sprite
				mySpriteRenderer.flipX = false;
				lastDir = 1;
			}
			//if down key is pressed
		}
	}
	#endregion

	


}