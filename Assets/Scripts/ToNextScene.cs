using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour {

	// Use this for initialization
    private int nextSceneToLoad;
	void Start () {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D op)
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
