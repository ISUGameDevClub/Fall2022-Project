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
        if(Vector2.Distance(this.transform.position, playerTransform.position) < activateDistance)
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
        anim.SetBool("ReadyIdle", true);
    }
    public void BurrowSnake()
    {
        anim.SetBool("ReadyIdle", false);
        anim.SetBool("ReadyBurrow", true);
        snakeOut = false;
    }
    public void AttackSnake()
    {
        if (!isAttacking)
        {
            hurtBox.SetActive(false);
            isAttacking = true;
            anim.SetBool("Attacking", true);
            StartCoroutine(AttackWait(attackCooldown));
        }
    }
    private IEnumerator AttackWait(float waitTime)
    {
        while (waitTime > 0)
        {
            yield return new WaitForSeconds(waitTime);
            isAttacking = false;
            anim.SetBool("Attacking", false);
            hurtBox.SetActive(false);
        }
    }
}
