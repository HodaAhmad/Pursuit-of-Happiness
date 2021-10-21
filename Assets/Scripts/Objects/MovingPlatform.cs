using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   



    public bool moveRight;
    public float speed;
    private Rigidbody2D r1;

    void Turn()
    {
        moveRight = !moveRight;
    }

    // Start is called before the first frame update
    void Start()
    {
        r1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.moveRight == true)
        {
            this.r1.velocity = new Vector2(speed, this.r1.velocity.y);
        }
        else
        {
            this.r1.velocity = new Vector2(-speed, this.r1.velocity.y);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TURN")
        {
            Turn();
        }
    }


}





