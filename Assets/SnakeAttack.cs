using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    [SerializeField]
    GameObject
        hurtBox;
    Transform
        playerTransform;
    bool
        isAttacking;
    bool
        snakeOut;
    [SerializeField]
    float
        activateDistance;
    [SerializeField]
    float
        attackCooldown;
    Animator
        anim;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        isAttacking = false;
        snakeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null && Vector2.Distance(this.transform.position, playerTransform.position) < activateDistance)
        {
            if (!snakeOut)
            {
                SpawnSnake();
            }
        }
        else
        {
            BurrowSnake();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            AttackSnake();
        }
    }
    public void SpawnSnake()
    {
        anim.SetBool("ReadyBurrow", false);
        anim.SetBool("ReadyEmerge", true);
        snakeOut = true;

    }
    public void IdleSnake()
    {
        hurtBox.SetActive(true);
        anim.SetBool("ReadyEmerge", false);
    }
    public void BurrowSnake()
    {
        anim.SetBool("ReadyBurrow", true);
        snakeOut = false;
    }
    public void AttackSnake()
    {
        if (!isAttacking)
        {
            hurtBox.SetActive(false);
            isAttacking = true;
            anim.SetTrigger("Attacking");
            StartCoroutine(AttackWait(attackCooldown));
        }
    }
    private IEnumerator AttackWait(float waitTime)
    {
        while (waitTime > 0)
        {
            yield return new WaitForSeconds(waitTime);
            isAttacking = false;
            hurtBox.SetActive(false);
        }
    }
}
