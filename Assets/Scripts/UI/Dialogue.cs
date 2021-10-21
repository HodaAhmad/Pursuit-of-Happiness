using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialogueSentences;
    private int index = 0;
    public float typingSpeed;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject dialogueBox;
    public GameObject other;
    public Rigidbody2D player;

    public GameObject boss;

    private PlayerScript pl;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        nextButton.SetActive(false);
        prevButton.SetActive(false);
        
        pl = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator typeDialogue()
    {
        dialogueBox.SetActive(true);
        other.SetActive(false);
        FindObjectOfType<LonelinessBoss>().enabled = false;
        player.constraints = RigidbodyConstraints2D.FreezeAll;
        //pl.flip = false;
        foreach(char letter in dialogueSentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            if(textDisplay.text==dialogueSentences[index])
            {
                nextButton.SetActive(true);
                if (index == 0)
                {
                    prevButton.SetActive(false);
                    
                }
                else
                {
                    prevButton.SetActive(true);
                }
            }
        }
    }

    public void setSentence(string[] Sentences)
    {
        this.dialogueSentences = Sentences;
    }

    public void nextSentence()
    {
        nextButton.SetActive(false);
        prevButton.SetActive(false);
        if (index < dialogueSentences.Length-1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(typeDialogue());
        }
        else
        {
            textDisplay.text = "";
            nextButton.SetActive(false);
            prevButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.dialogueSentences = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
            other.SetActive(true);
            FindObjectOfType<LonelinessBoss>().enabled = true;
            //pl.flip = true;
        }
    }

    public void prevSentence()
    {
        nextButton.SetActive(false);
        prevButton.SetActive(false);
        if (index < dialogueSentences.Length - 1)
        {
            index--;
            textDisplay.text = "";
            StartCoroutine(typeDialogue());
        }
        else
        {
            textDisplay.text = "";
            nextButton.SetActive(false);
            prevButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.dialogueSentences = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
            other.SetActive(true);
            FindObjectOfType<LonelinessBoss>().enabled = true;
            //pl.flip = true;
        }
    }
}
