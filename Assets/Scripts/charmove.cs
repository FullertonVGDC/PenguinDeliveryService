using UnityEngine;
using System.Collections;

public class charmove : MonoBehaviour
{
    public CharacterController controller;
    float walkspeed = 7;
    float slidespeed = 3;
    Rigidbody2D rb;
    Vector3 startingPosition; // If we are too far underwater we will teleport player to starting position.
    public GameObject playerObject;
    public AudioClip snow;
    public AudioClip hop;
    public AudioClip[] sounds;
    public AudioSource intrusment;
    public bool isDoubleJump = true;
    public bool isOnGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the script and store it in rb
        startingPosition = transform.position;
    }

    public void Replay()
    {
        StartCoroutine("ReplayRoutine");
    }

    void Update()
    {
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * walkspeed;

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        //jump (press twice to double jump) with sound effect
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isOnGround)
            {
                isOnGround = false;
                rb.AddForce(new Vector3(0, 300, 0)); // Adds 100 force straight up, might need tweaking on that number
                playsound(1);
            }
            {
                if (isDoubleJump)
                {
                    rb.AddForce(new Vector3(0, 300, 0)); // Adds 100 force straight up, might need tweaking on that number
                    playsound(1);
                }
            }
            //debug with rigidbody movement only

        }

        //slide (duck down and move left or right simultaneously) with momentum
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<BoxCollider2D>().enabled = false; //disable top collider as long as down+L/R is active
           //player should be able to walk under low areas
        }
        else
        {
     
            playerObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        //walk with sound effect
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playsound(0);
        }
    }

    private void playsound(int index)
    {
        intrusment.clip = sounds[index];
        intrusment.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
    }

}