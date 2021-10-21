using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    public AIPath aiPath;
    public Collider2D co;

  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f) transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y, transform.localScale.z);
        else if (aiPath.desiredVelocity.x <= -0.01f) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            FindObjectOfType<PlayerStats>().takeDamage(1,false);
            co.isTrigger = true;
            StartCoroutine(passThrough());
        }
    }
    IEnumerator passThrough()
    {
        yield return new WaitForSeconds(1.5f);
        co.isTrigger = false;
    }
}
