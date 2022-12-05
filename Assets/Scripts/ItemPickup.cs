using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup: MonoBehaviour
{
    private bool hasHat;
    public string pickupType;
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
        Destroy(gameObject);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null) 
        {
            collision.gameObject.GetComponent<Health>().gainHealth(pickupType,GetComponentInChildren<SpriteRenderer>().sprite);
            PickMeUp(); 
        }
    }
}
