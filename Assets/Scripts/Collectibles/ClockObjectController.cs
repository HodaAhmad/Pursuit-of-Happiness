using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockObjectController : MonoBehaviour
{
    private CountDownTimer timer;
    public int seconds;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<CountDownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            timer.currentTime += seconds;
            Destroy(gameObject);
        }
    }
}
