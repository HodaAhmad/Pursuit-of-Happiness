using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static AudioManager instance = null;
    public float lowPitch = .95f;
    public float highPitch = 1.05f;

    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void RandomizeSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitch, highPitch);

        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];

        efxSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
