using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    public float currentTime = 0f;
    public Text stopWatchText;
    public float highScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        stopWatchText.text = currentTime.ToString("0");
        highScore = currentTime;
    }
}
