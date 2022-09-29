using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour   
{
    public float speed_enemy = 1.0f;
    private Rigidbody2D rb;
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
        rb.MovePosition(rb.position + new Vector2(-1, 0) * Time.deltaTime * speed_enemy);
    }
}
