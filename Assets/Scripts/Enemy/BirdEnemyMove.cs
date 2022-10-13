using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float enemy_speed = 4;
    public float walldetectrange = 5;
    [SerializeField] float height = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + new Vector2(-1, -1) * Time.deltaTime * enemy_speed);

        Create2DRay();


    }

    private void Create2DRay()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, height, mask);

        if (hit.collider != null)
        {
            rb.MovePosition(rb.position + new Vector2(-1, 0) * Time.deltaTime * enemy_speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
