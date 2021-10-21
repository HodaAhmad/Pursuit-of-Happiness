using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public bool isFacingRight;
    public float maxSpeed;
    private Rigidbody2D r1;
    public Transform target;
    private Animator anim;
    private PlayerScript PlayerSc;
    



    // Start is called before the first frame update
    void Start()
    {
        PlayerSc = FindObjectOfType<PlayerScript>();
        anim = GetComponent<Animator>();
        isFacingRight = PlayerSc.isFacingRight;
        
        target = FindObjectOfType<Transform>();
        
    }

    public void setAnimation(string dogstate)
    {
        if (dogstate == "Idle")
        {
            anim.SetBool("Idle", true);
            anim.SetBool("walk", false);
            
        }
        else if (dogstate == "walk")
        {
            anim.SetBool("Idle", false);
            anim.SetBool("walk", true);
            
        }
    }


    // Update is called once per frame
    void Update()
    {



    }


}
