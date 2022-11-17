using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float enemy_speed = 4;
    private Rigidbody2D rb;
    public float wallDetectRange = 1;
    private float direction = 1.0f;
    float height = 99;
    SpriteRenderer sR;

    // Start is called before the first frame update
    
    //BIRD DESPAWNING STUFF
    //make bird despawn (destroy function) when off camera
    //make bird despawn when hits platform/player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Create2DRay();
        Create2DForwardRay();
    }
    private void Create2DRay()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, height, mask);

        if (hit.collider != null)
        {
            rb.MovePosition(rb.position + new Vector2(-1, 0) * Time.deltaTime * enemy_speed * direction);
        }
        else
        {
            rb.MovePosition(rb.position + new Vector2(-1, -1) * Time.deltaTime * enemy_speed * direction);
        }
    }
    private void Create2DForwardRay()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 1f, 0), Vector2.left * direction, wallDetectRange, mask);
        if (hit.collider != null)
        {
            direction = direction * -1;
            sR.flipX = !sR.flipX;
        }
    }
}
