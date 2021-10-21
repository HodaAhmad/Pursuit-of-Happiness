using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour {

	// Use this for initialization
    PlayerStats player;
	void Start () {
        player = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D oth) {

        if (oth.tag == "PLAYER")
        {

            FindObjectOfType<LevelManager>().Respawn();
            player.takeDamage(player.happiness, false);


        }
    }
}
