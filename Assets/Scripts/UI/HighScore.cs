using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    private StopWatch score;
    public TextMeshProUGUI highscore;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<StopWatch>();
    }

    // Update is called once per frame
    void Update()
    {
        highscore.text = ("Score: " + Stopwatch.highScore.ToString("0"));
       
    }
}
