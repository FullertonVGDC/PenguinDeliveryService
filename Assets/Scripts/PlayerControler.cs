using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    #region Data Member
    float walkspeed = 7;
    float slidespeed = 3;
    Rigidbody2D rigid;
    Vector3 startingPosition; // If we are too far underwater we will teleport player to starting position.
    public GameObject playerObject;
    public AudioClip[] sounds;
    public AudioSource intrusment;
    public bool isDoubleJump = true;
    bool isOnGround = false;

    #endregion
    #region Getter Setter
    #endregion
    #region Built - in Method
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the script and store it in rb
        startingPosition = transform.position;
    }
    void Update()
    {
        Walk();
        //jump (press twice to double jump) with sound effect
        Jump();

        //slide (duck down and move left or right simultaneously) with momentum
        if (Input.GetKey(KeyCode.DownArrow))
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
    }
    #endregion
    #region Public Method
    #endregion
    #region Private Method
    private void Walk()
    {
        float movement = Input.GetAxis("Horizontal") * walkspeed;
        rigid.velocity = new Vector3(movement, rigid.velocity.y, 0);

    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isOnGround)
            {
                isOnGround = false;
                rigid.AddForce(new Vector3(0, 300, 0)); // Adds 100 force straight up, might need tweaking on that number
                playsound(1);
            }
            {
                if (isDoubleJump)
                {
                    rigid.AddForce(new Vector3(0, 300, 0)); // Adds 100 force straight up, might need tweaking on that number
                    playsound(1);
                }
            }
        }
    }

    private void playsound(int index)
    {
        intrusment.clip = sounds[index];
        intrusment.Play();
    }
    #endregion







}