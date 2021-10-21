using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Stopwatch : MonoBehaviour
{
    public static float currentTime = 0;
    public TextMeshProUGUI stopWatchText;
    public static float highScore;


    // Start is called before the first frame update
    void Start()
    {
        highScore = currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        stopWatchText.text = currentTime.ToString("0");
        highScore = currentTime;
    }

 
}
