using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    private float direction = 1.0f;
    private Rigidbody2D rb;
    [SerializeField] float fallSpeed;
    public float wallDetectRange = 5;
    public float enemySpeed = 4;
    SpriteRenderer sR;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponentInChildren<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        if (GetComponent<EnemyHealth>().frozen <= 0)
        {
            rb.velocity = Vector2.zero;
            rb.MovePosition(rb.position + new Vector2(-1, 0) * Time.fixedDeltaTime * direction * enemySpeed + new Vector2(0, fallSpeed) * Time.fixedDeltaTime);
            Create2DRay();
        }
    }
    public float GetDirection()
    {
        return direction;
    }
    private void Create2DRay()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0,1f,0), Vector2.left * direction, wallDetectRange, mask);
        if (hit.collider != null)
        {
            direction = direction * -1;
            sR.flipX = !sR.flipX;
        }   
    }
}