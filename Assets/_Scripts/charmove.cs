using UnityEngine;
using System.Collections;

public class charmove : MonoBehaviour
{
    public CharacterController controller;
    float walkspeed = 7;
    float slidespeed = 3;
    Rigidbody2D rigid;

    public GameObject playerObject;
    public GameObject groundObject;

    public AudioClip snow; //sound effect 0 in array
    public AudioClip hop; //sound effect 1 in array
    public AudioClip levelend; //sound effect 3 in array

    public AudioClip[] sounds; //array to hold sounds, sounds must be called by position in index
    public AudioSource instrument;
    public bool isDoubleJump = true;
    public bool isOnGround = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    public void Replay()
    {
        StartCoroutine("ReplayRoutine");
    }

    void Update()
    {
        var input = Input.GetAxis("Horizontal"); //left and right movement 
        var movement = input * walkspeed;

        rigid.velocity = new Vector3(movement, rigid.velocity.y, 0);


        //the following code ignores layer collisions between Character and PassThru (ground tiles in the PassThru label) when the player jumps
        //NOTE: on ground tiles that have a larger height than player's current jump height, player will get stuck in the tile, so all PassThru tiles should be thin
        Debug.Log(rigid.velocity.y > 0);
        //layer 10 is Platform, layer 11 is Character, layer 12 is PassThru
        Debug.Log(Physics2D.GetIgnoreLayerCollision(11, 12));
        if (rigid.velocity.y > 0)
        {
            //note: ground tiles labelled PassThru are the only ones that can be jumped through with below code
            Physics2D.IgnoreLayerCollision(11, 12, true);
            Debug.Log("Pass through the platform!");
        }
        //if player falls from jumping, player can land on the platform instead of falling through
        else
        {
            Physics2D.IgnoreLayerCollision(11, 12, false);
        }

        //jump (press twice to double jump) with sound effect
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isOnGround)
            {
                isOnGround = false;
                rigid.AddForce(new Vector3(0, 300, 0));
                playsound(1);
            }
            {
                if (isDoubleJump)
                {
                    rigid.AddForce(new Vector3(0, 100, 0)); //adds a little more force to jump
                    playsound(1);
                }
            }
        }

        //slide (duck down and move left or right simultaneously) with momentum
        /*
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<BoxCollider2D>().enabled = false; //disable top collider as long as down+L/R is active
           //player should be able to walk under low areas
        }
        else
        {
     
            playerObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        */

        //walk with sound effect
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playsound(0);
        }
    }

    private void playsound(int index)
    {
        instrument.clip = sounds[index];
        instrument.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }

        //when player lands on a platform designating the end of a level
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            //show new sprite "Level Complete" text on screen
            LevelManager._instance.ReachDestination(collision.gameObject.name); //just need tagged name of the gameObject
            isOnGround = true;
            Debug.Log("You reached the end of the level");
            playsound(2);
        }
    }
}