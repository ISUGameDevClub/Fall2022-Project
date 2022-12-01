using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raccoon : MonoBehaviour
{
    Transform 
        playerTransform;
    SpriteRenderer 
        sR;
    Animator
        enAnim;
    [SerializeField]
    float
        activateDistance;
    [SerializeField]
    GameObject
        proj;
    bool 
        isFlipped;
    bool
        isShooting;


    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        enAnim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (GetComponent<EnemyHealth>().frozen <= 0)
        {
            if (Vector2.Distance(this.transform.position, playerTransform.position) < activateDistance)
            {
                enAnim.SetBool("Attack", true);
            }
            else
            {
                enAnim.SetBool("Attack", false);
            }
        }
        if (playerTransform.position.x > transform.position.x)
        {
            isFlipped = true;
            sR.flipX = isFlipped;
        }else
        {
            isFlipped = false;
            sR.flipX = isFlipped;
        }
    }
    public void Shoot ()
    {
        GameObject tempProj = Instantiate(proj, transform.position, Quaternion.identity);
        if (isFlipped)
        {
            tempProj.GetComponentInChildren<SpriteRenderer>().flipX = true;
            tempProj.GetComponent<Attack>().moveDirection = Vector2.right;
        }
        else
        {
            tempProj.GetComponentInChildren<SpriteRenderer>().flipX = false;
            tempProj.GetComponent<Attack>().moveDirection = Vector2.left;
        }
    }
    public void MakeInvincible()
    {
        GetComponent<EnemyHealth>().invincible = true;
    }
    public void MakeVulnerable()
    {
        GetComponent<EnemyHealth>().invincible = false;
    }
}
