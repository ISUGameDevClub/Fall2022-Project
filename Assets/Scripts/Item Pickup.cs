using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool hasHat;

    Rigidbody playerRB;
    Rigidbody hatPickup; 


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        hatPickup = GetComponent<Rigidbody>();

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickMeUp()
    {
        //Need to get health method from other groups, want to destroy the hat pickup and change sprite to one to hat

        //gainHealth();
        //Destroy(gameObject.tag("HatPickup"));
    }

    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            PickMeUp(); 
           
        }
    }
}
