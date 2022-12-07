using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool midBoss;
    public GameObject midBossGO;
    private GameObject player;
    public GameObject otherDoor;
    public BoxCollider2D col;
    public SpriteRenderer sr;

    private bool fightStarted;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        if(midBoss)
            midBossGO.GetComponent<EnemyHealth>().invincible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!fightStarted && player.transform.position.x > transform.position.x + 1.5f)
        {
            fightStarted = true;
            if (!midBoss)
                FindObjectOfType<Boss>().StartFight();
            else
            {
                midBossGO.GetComponent<DogMovement>().enemySpeed = 15;
                midBossGO.GetComponent<EnemyHealth>().invincible = false;
            }
            col.enabled = true;
            sr.enabled = true;
        }   
        else if (fightStarted)
        {
            if (!midBoss)
            {
                if (FindObjectOfType<Boss>() == null)
                {
                    FindObjectOfType<Timer>().StopTimer();
                    Destroy(otherDoor);
                }
            }
            else
            {
                if (midBossGO == null && FindObjectOfType<FishShoot>() == null)
                {
                    Destroy(otherDoor);
                }
            }
        }
    }
}
