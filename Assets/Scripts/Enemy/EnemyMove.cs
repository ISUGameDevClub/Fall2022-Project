using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float direction = 1.0f;
    private Rigidbody2D rb;
    public float walldetectrange = 5;
    public float enemy_speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Rigidbody.position.x < -1.5)
        // {
        //     speed_enemy = speed_enemy * -1;
        // }
        rb.MovePosition(rb.position + new Vector2(-1, 0) * Time.deltaTime * direction * enemy_speed);

        Create2DRay();
    }
    private void Create2DRay()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * direction, 1, mask);

        if (hit.collider != null)
        {
            direction = direction * -1;
        }
    }
}