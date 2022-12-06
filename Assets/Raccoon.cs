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
    [SerializeField]
    AudioClip
        cloak;
    [SerializeField]
    AudioClip
        deCloak;
    [SerializeField]
    AudioSource
        raccoonSounds;
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
        if (GetComponent<EnemyHealth>().frozen <= 0 && playerTransform != null)
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
        if (playerTransform != null && playerTransform.position.x > transform.position.x)
        {
            isFlipped = true;
            sR.flipX = isFlipped;
        }else if(playerTransform != null)
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
        raccoonSounds.clip = cloak;
        raccoonSounds.Play();
        GetComponent<EnemyHealth>().invincible = true;
    }
    public void MakeVulnerable()
    {
        raccoonSounds.clip = deCloak;
        raccoonSounds.Play();
        GetComponent<EnemyHealth>().invincible = false;
    }
}
