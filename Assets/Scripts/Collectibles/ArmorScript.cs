using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorScript : MonoBehaviour
{
    public static bool armorOn;
    public Image Armor;

    // Start is called before the first frame update
    void Start()
    {
        armorOn = false;
        Armor.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER")
        {
            armorOn = true;
            Armor.enabled = true;
            Destroy(gameObject);
        }
    }
}
