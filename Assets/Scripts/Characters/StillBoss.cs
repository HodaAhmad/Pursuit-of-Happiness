using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StillBoss : MonoBehaviour {

	// Use this for initialization


    public int BossHealth = 10;

    [SerializeField]
    public  GameObject balls;
    int ballCount;
    float fireRate;
    float nextFire;

    public PlayerStats Pstats;
    public Slider HP;

   

    // Start is called before the first frame update
    void Start()
    {
        
        ballCount = 0;
        fireRate = 1f;
        nextFire = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        checkIfToFire();
        if (BossHealth <= 0) {
            Destroy(gameObject);
            GoToFearChoice();
        }
        HP.value = BossHealth; 
    }

    public void checkIfToFire()
    {
        if (ballCount < 5)
        {
            if (Time.time > nextFire)
            {
                Instantiate(balls, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
                ballCount++;
            }
        }
        else
        {
            StartCoroutine("WaitCoroutine");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            Pstats.takeDamage(2, false);
        }

        if (other.tag == "Weapon") {
            BossHealth = BossHealth - (FindObjectOfType<Sword>().SwordDmg);
        }
    }

    public IEnumerator WaitCoroutine()
    {

        yield return new WaitForSeconds(5f);
        ballCount = 0;

    }

    public void GoToFearChoice()
    {
        Application.LoadLevel(3);
    }
  
}
