using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownBalls : MonoBehaviour {

    public float speed = 2f; // it was 3 
    Rigidbody2D rb;

    public static PlayerScript target;
    PlayerStats Pstats;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerScript>();
        Pstats = FindObjectOfType<PlayerStats>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
            Pstats.takeDamage(Pstats.happiness, false);
        }
    }
}
