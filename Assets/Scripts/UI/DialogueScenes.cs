using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScenes : MonoBehaviour
{
    public DailougeDog dialogueManager;
    public CircleCollider2D EC;
    DogScript dog;

   
    // Start is called before the first frame update
    void Start()
    {
        EC = GetComponent<CircleCollider2D>();
        dog = FindObjectOfType<DogScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            //dog.transform.localScale = new Vector3(-dog.transform.localScale.x, dog.transform.localScale.y, dog.transform.localScale.z);
           
            string[] dialogueDog = { "Player: Ooh Hello There!",
                                  "Dog: Woof!!",
                                  "Player: I guess you're lost!",
                                  "Player: Follow me!",
                                  "Dog: Woof!!" };

            dialogueManager.setSentence(dialogueDog);
            dialogueManager.StartCoroutine(dialogueManager.typeDialogue());
            EC.enabled = false;
        }
    }
}
