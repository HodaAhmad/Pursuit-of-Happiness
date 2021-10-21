using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    public PlayerStats Pstats;
    public AudioClip candyCollect;

    // Start is called before the first frame update
    void Start()
    {
        Pstats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            if (Pstats.happiness != 10)
            {
                AudioManager.instance.PlaySingle(candyCollect);
                Pstats.happiness += 1;
                Destroy(gameObject);
            }

        }

    }
}
