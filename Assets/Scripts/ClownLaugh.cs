using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownLaugh : MonoBehaviour {

    public AudioClip laugh;
    public Collider2D co;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="PLAYER")
        {
            AudioManager.instance.PlaySingle(laugh);
            Destroy(co);
        }
    }
}
