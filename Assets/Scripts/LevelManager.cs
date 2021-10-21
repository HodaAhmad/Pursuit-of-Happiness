using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerScript gamePlayer;
   

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
        StartCoroutine(UnFreeze());
    }

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }

    public IEnumerator UnFreeze() {

        yield return new
        WaitForSeconds(1.5f);
        gamePlayer.r1.constraints = RigidbodyConstraints2D.None;
        gamePlayer.r1.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


}
