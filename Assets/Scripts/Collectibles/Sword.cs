using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	// Use this for initialization
    public float speed = 10;
    public int SwordDmg = 2;
    private PlayerScript player;
    private Rigidbody2D sword;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        sword = GetComponent<Rigidbody2D>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            sword.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sword.velocity = new Vector2(speed, sword.velocity.y);
        Destroy(gameObject, .35f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boss")
        {

            Destroy(gameObject);

        }
        
        
    }
}
