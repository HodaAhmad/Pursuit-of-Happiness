using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LonelinessBoss : MonoBehaviour {

	// Use this for initialization

    public bool isFacingRight;
    public float maxSpeed;
    private Rigidbody2D r1;
    public int damage = 1;
    float movement;
    bool shouldMove;

    public int BossHealth = 15;
    public Slider HP;
   // public const float hpDecrease = 2f; 


    //serialized field

    public GameObject balls;
    int ballCount;
    float fireRate;
    float nextFire;

    public PlayerStats Pstats;


    void Flip()
    {
        // isFacingRight = !isFacingRight;
        //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        maxSpeed = -maxSpeed;

    }

    // Start is called before the first frame update
    void Start()
    {
        ballCount = 0;
        fireRate = 4.5f; // it was 0.5
        nextFire = Time.time;
        r1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfToFire();
        if (this.isFacingRight == true)
        {
            this.r1.velocity = new Vector2(maxSpeed, this.r1.velocity.y);
        }
        else
        {
            this.r1.velocity = new Vector2(-maxSpeed, this.r1.velocity.y);
        }
        if (BossHealth <= 0)
        {
            Destroy(gameObject);
            GoToNextLevel();
        }

        //Pstats.happiness -= (int)(hpDecrease * Time.deltaTime);
        HP.value = BossHealth; 
    }

    public void checkIfToFire()
    {
        if (ballCount < 3)
        {
            if (Time.time > nextFire)
            {
                Instantiate(balls, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
                ballCount++;
            }
        }
        else
        {
            StartCoroutine("WaitCoroutine");
        }
    }

    public IEnumerator WaitCoroutine()
    {

        yield return new WaitForSeconds(5f);
        ballCount = 0;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WALL")
        {
            Flip();
        }
        else if (other.tag == "ENEMY")
        {
            Flip();
        }
        if (other.tag == "PLAYER")
        {
            FindObjectOfType<PlayerStats>().takeDamage(damage, false);
            Flip();
        }
        if (other.tag == "TURN")
        {
            Flip();
        }
        if (other.tag == "Weapon")
        {
            BossHealth--;
        }
    }
    public void GoToNextLevel()
    {
        Application.LoadLevel(12);
    }
}
