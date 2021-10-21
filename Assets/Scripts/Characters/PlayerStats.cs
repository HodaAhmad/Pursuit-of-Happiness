using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int happiness = 5;
    public static int lives = 3;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    
    public AudioClip GameOverSound;
    public AudioClip HitSFX;
    public AudioClip DieSFX;

    public HeartCollector heart;
    public ArmorScript armor;

    public Slider HappinessUI;

    PlayerScript player; public KeyCode boost; Boost bar;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        heart = FindObjectOfType<HeartCollector>();
        armor = FindObjectOfType<ArmorScript>();
        bar = FindObjectOfType<Boost>();
        
    }

    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    public void takeDamage(int damage, bool killedAtOnce)
    {
        if (killedAtOnce == true)
        {
            if (lives == 3)
            {
                heart.heart3.enabled = false;
                heart.heart2.enabled = true;
                heart.heart1.enabled = true;
                happiness = 5;
            }
            else if (lives == 2)
            {
                heart.heart3.enabled = false;
                heart.heart2.enabled = false;
                heart.heart1.enabled = true;
                happiness = 5;
            }
            else if (lives == 1)
            {
                heart.heart3.enabled = false;
                heart.heart2.enabled = false;
                heart.heart1.enabled = false;
                happiness = 5;
            }
            else if (lives <= 0)
            {
                (new NavigationController()).GoToGameOverScene();
                AudioManager.instance.PlaySingle(GameOverSound);
                AudioManager.instance.musicSource.Stop();
                Debug.Log("Game Over");
                Destroy(this.gameObject);
                return;
            }
            AudioManager.instance.PlaySingle(DieSFX);
            FindObjectOfType<LevelManager>().Respawn();
            lives--;
            happiness = 5;
            ArmorScript.armorOn = false;
            armor.Armor.enabled = false;
        }
        else if (ArmorScript.armorOn == false)
        {
            if (this.isImmune == false)
            {
                if (happiness > 0) AudioManager.instance.PlaySingle(HitSFX);
                happiness = happiness - damage;
                if (happiness < 0)
                {
                    happiness = 0;
                }
                if (lives > 0 && happiness == 0)
                {
                    if (lives == 3)
                    {
                        heart.heart3.enabled = false;
                        heart.heart2.enabled = true;
                        heart.heart1.enabled = true;
                    }
                    else if (lives == 2)
                    {
                        heart.heart3.enabled = false;
                        heart.heart2.enabled = false;
                        heart.heart1.enabled = true;
                    }
                    else if (lives == 1)
                    {
                        heart.heart3.enabled = false;
                        heart.heart2.enabled = false;
                        heart.heart1.enabled = false;
                    }
                    AudioManager.instance.PlaySingle(DieSFX);
                    FindObjectOfType<LevelManager>().Respawn();
                    lives--;
                    happiness = 5;
                }
                else if (lives <= 0 && happiness == 0)
                {
                    (new NavigationController()).GoToGameOverScene();
                    AudioManager.instance.PlaySingle(GameOverSound);
                    AudioManager.instance.musicSource.Stop();
                    Debug.Log("Game Over");
                    Destroy(this.gameObject);
                }
                Debug.Log("Player HP: " + happiness.ToString());
                Debug.Log("Player Lives: " + lives.ToString());
            }
            PlayHitReaction();
        }
        else
        {
            ArmorScript.armorOn = false;
            armor.Armor.enabled = false;
        }
    }
  

    // Update is called once per frame
    void Update()
    {
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
                Debug.Log("Immunity Has Ended");
            }
        }
        HappinessUI.value = happiness;
        if (happiness == 10) //IN UPDATE METHOD
        {
            bar.boostBar.enabled = true;
            if (Input.GetKeyDown(boost) == true)
            {
                StartCoroutine(Boost());
                happiness = 5;
                bar.boostBar.enabled = false;
            }
        }
    }



    IEnumerator Boost()
    {
        player.speed = 5.5f;
        player.jumpHeight = 8;
        yield return new WaitForSeconds(6.5f);
        player.speed = 3;
        player.jumpHeight = 6.5f;
    }
    
}
