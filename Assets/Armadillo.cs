using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadillo : MonoBehaviour
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
    float
        attackWait;
    bool
        isFlipped;
    bool
        canAttack;


    private void Start()
    {
        canAttack = false;
        StartCoroutine(AttackWait());
        sR = GetComponentInChildren<SpriteRenderer>();
        enAnim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (GetComponent<EnemyHealth>().frozen <= 0)
        {
            if (Vector2.Distance(this.transform.position, playerTransform.position) < activateDistance & canAttack)
            {
                Shoot();
            }
        }
        if (playerTransform.position.x > transform.position.x)
        {
            isFlipped = true;
            sR.flipX = isFlipped;
        }
        else
        {
            isFlipped = false;
            sR.flipX = isFlipped;
        }
    }
    public void Shoot()
    {
        canAttack = false;
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
        StartCoroutine(AttackWait());
    }
    private IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(attackWait);
        canAttack = true;
    }
}
