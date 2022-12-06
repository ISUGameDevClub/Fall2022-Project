using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject player;
    public GameObject otherDoor;
    public BoxCollider2D col;
    public SpriteRenderer sr;

    private bool fightStarted;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!fightStarted && player.transform.position.x > transform.position.x + 1.5f)
        {
            fightStarted = true;
            FindObjectOfType<Boss>().StartFight();
            col.enabled = true;
            sr.enabled = true;
        }   
        else if (fightStarted)
        {
            if(FindObjectOfType<Boss>() == null)
            {
                Destroy(otherDoor);
            }
        }
    }
}
