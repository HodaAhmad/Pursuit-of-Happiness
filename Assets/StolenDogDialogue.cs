using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenDogDialogue : MonoBehaviour {

	// Use this for initialization
    public Dialogue dialogueManager;
    public CircleCollider2D EC;
    //public GameObject boss;
    

    // Start is called before the first frame update
    void Start()
    {
        EC = GetComponent<CircleCollider2D>();
       // boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            
            string[] dialogue = { "Boss: MOAHAHA I took your dog!!",
                                  "Player: NOoOoo ",
                                  "Player: I shall retrieve him ",
                                  "Boss: you can try but you will die"
                                   };
            dialogueManager.setSentence(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.typeDialogue());
           /// boss.enabled=true;
            EC.enabled = false;
            
        }
    }
}
