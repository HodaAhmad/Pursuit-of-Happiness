using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public KeyCode fire;
    public Transform firePoint;
    public GameObject sword;
    public bool isExists = false;
    public bool vsBoss;

    public int maxAmmo = 3;
    public int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isRelodaing = false;

    public AudioClip fireSound;

    // Use this for initialization
    void Start()
    {
        vsBoss = false;
        currentAmmo = maxAmmo;
    }
    private void Fire()
    {
        currentAmmo--;
        Instantiate(sword, firePoint.position, firePoint.rotation);
        isExists = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isRelodaing)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(fire) && vsBoss == true)
        {
            AudioManager.instance.PlaySingle(fireSound);
            Fire();
        }
    }
    IEnumerator Reload()
    {
        isRelodaing = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isRelodaing = false;

    }
}
