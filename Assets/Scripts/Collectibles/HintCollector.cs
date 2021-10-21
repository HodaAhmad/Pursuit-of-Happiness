using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintCollector : MonoBehaviour
{
    public GameObject hintImage;
    public GameObject hintText;
    public GameObject hintButton;

    // Start is called before the first frame update
    void Start()
    {
        hintImage.SetActive(false);
        hintText.SetActive(false);
        hintButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="PLAYER")
        {
            hintImage.SetActive(true);
            hintText.SetActive(true);
            hintButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void destroy()
    {
        hintImage.SetActive(false);
        hintText.SetActive(false);
        hintButton.SetActive(false);
        Destroy(gameObject);
    }
}
