using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{



    public float speed = 5f;
    public float jumpHeight = 8f;
    private float movement = 0f;
    public Rigidbody2D r1;
    public bool isFacingRight;
    public Transform groundCheckPoint; public float groundCheckRadius; public LayerMask groundLayer; public bool isTouchingGround; //For Jump.
    private Animator playerAnimation; //For Animations.
    public Vector3 respawnPoint;
    private LevelManager gameLevelManager;
    private PlayerStats Pstats;
    public AudioClip JumpSFX;
    public float distance; public LayerMask whatIsPole; private bool isClimbing; private float inputVertical; public float climbSpeed; //Climbing pole
    private Weapon Wp;
    public Image weap;
    


    // Start is called before the first frame update
    void Start()
    {
        r1 = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        isFacingRight = true;
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
        Pstats = FindObjectOfType<PlayerStats>();
        Wp = FindObjectOfType<Weapon>();
        groundCheckRadius = 0.2f;
        weap.enabled = false;
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer); //Checking if The Player is touching the ground.
        if (Input.GetButtonDown("Jump") && isTouchingGround) //Jump condition
        {
            AudioManager.instance.PlaySingle(JumpSFX);
            r1.velocity = new Vector2(r1.velocity.x, jumpHeight);
        }
        movement = Input.GetAxis("Horizontal"); //Checking if the player is moving left or right.
        if (movement > 0f) //Moving right condition.
        {
            r1.velocity = new Vector2(movement * speed, r1.velocity.y);
            if (!isFacingRight)
            {
                Flip();
                isFacingRight = true;
            }
            
        }
       
        else if (movement < 0f) //Moving left condition.
        {
            r1.velocity = new Vector2(movement * speed, r1.velocity.y);
            if (isFacingRight)
            {
                Flip();
                isFacingRight = false;
            }
          
        }
        playerAnimation.SetFloat("Speed", Mathf.Abs(r1.velocity.x)); playerAnimation.SetBool("Grounded", isTouchingGround); //Walk and Jump Animations
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsPole); //https://www.youtube.com/watch?v=Ln7nv-Y2tf4
        if (hitInfo.collider != null) //Check if it collides
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        }
        else
        {
            isClimbing = false;
        }

        if (isClimbing)
        {
            inputVertical = Input.GetAxis("Vertical");
            r1.velocity = new Vector2(r1.velocity.x, inputVertical * climbSpeed);
            r1.gravityScale = 0;
        }
        else
        {
            r1.gravityScale = 1;
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FALLDETECTOR")
        {
            Pstats.takeDamage(5, true);
            gameLevelManager.Respawn();
        }
        if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
        if (other.tag == "WEB") //ADD THIS IN THE ONTRIGGERENTER2D function
        {
            r1.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(UnFreeze());
        }
        if (other.tag == "Weapon")
        {
            Wp.vsBoss = true;
            weap.enabled = true;
            Destroy(other.gameObject);

        }
        
    }
    IEnumerator UnFreeze()
    {
        yield return new WaitForSeconds(1.5f);
        r1.constraints = RigidbodyConstraints2D.None;
        r1.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
     
    


    }


