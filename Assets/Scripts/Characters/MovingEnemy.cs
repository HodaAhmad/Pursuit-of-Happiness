using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public bool isFacingRight;
    public float maxSpeed;
    private Rigidbody2D r1;
    public int damage = 1;
    public Collider2D co;

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        r1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isFacingRight == true)
        {
            this.r1.velocity = new Vector2(maxSpeed, this.r1.velocity.y);
        }
        else
        {
            this.r1.velocity = new Vector2(-maxSpeed, this.r1.velocity.y);
        }
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
            FindObjectOfType<PlayerStats>().takeDamage(damage,false);
            co.isTrigger = true;
            StartCoroutine(passThrough());
            Flip();
        }
        if (other.tag == "TURN")
        {
            Flip();
        }
    }

    IEnumerator passThrough()
    {
        yield return new WaitForSeconds(1.5f);
        co.isTrigger = false;
    }
    
}


