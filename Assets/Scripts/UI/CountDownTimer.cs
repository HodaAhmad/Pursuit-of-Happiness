using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime=0f;
    private float startingTime=60f;
    public Text countdownText;
    private PlayerStats Pstats;
    public LevelManager x;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        Pstats = FindObjectOfType<PlayerStats>();
        x = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pstats.isImmune == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime > 3f)
            {
                countdownText.color = Color.white;
            }

            if (currentTime <= 3f)
            {
                countdownText.color = Color.red;
            }

            if (currentTime <= 0)
            {
                currentTime = 0;
                Pstats.takeDamage(5,true);
                currentTime = startingTime + x.respawnDelay;
            }
        }
    }
}
