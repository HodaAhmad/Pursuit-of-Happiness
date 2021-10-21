using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillEnemy : MonoBehaviour {

	// Use this for initialization
    public int damage = 1;
    public Collider2D co;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D oth) {

        if (oth.tag == "PLAYER") {

            FindObjectOfType<PlayerStats>().takeDamage(damage, false);
        }
    }
    IEnumerator passThrough()
    {
        yield return new WaitForSeconds(1.5f);
        co.isTrigger = false;
    }
}
