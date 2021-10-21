using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCollector : MonoBehaviour
{
  //  private PlayerStats Pstats;
    public RawImage heart1,heart2,heart3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.lives == 3)
        {
            heart3.enabled = true;
            heart2.enabled = true;
            heart1.enabled = true;
        }
        else if (PlayerStats.lives == 2)
        {
            heart3.enabled = false;
            heart2.enabled = true;
            heart1.enabled = true;
        }
        else if (PlayerStats.lives == 1)
        {
            heart3.enabled = false;
            heart2.enabled = false;
            heart1.enabled = true;
        }
        else if (PlayerStats.lives <= 0)
        {
            heart3.enabled = false;
            heart2.enabled = false;
            heart1.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            if (PlayerStats.lives < 3)
            {
                if (PlayerStats.lives == 2)
                {
                    heart3.enabled = true;
                    PlayerStats.lives = 3;
                    Destroy(gameObject);
                }
                else if (PlayerStats.lives == 1)
                {
                    heart2.enabled = true;
                    PlayerStats.lives = 2;
                    Destroy(gameObject);
                }
                else if (PlayerStats.lives == 0)
                {
                    heart1.enabled = true;
                    PlayerStats.lives = 1;
                    Destroy(gameObject);
                }

            }
            else
                Debug.Log("You have maximum number of lives!");
        }
    }
}
