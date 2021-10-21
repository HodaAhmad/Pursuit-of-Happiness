using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBoss : MonoBehaviour {

	// Use this for initialization
    Vector3 localScale;

	void Start () {
        localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        localScale.x = FindObjectOfType<StillBoss>().BossHealth;
        transform.localScale = localScale;
	}
}
