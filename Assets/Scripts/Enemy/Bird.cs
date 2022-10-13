using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float enemy_speed = 4;
    private Rigidbody2D rb;
    public float walldetectrange = 1;
    private float direction = 1.0f;
    [SerializeField]float height = 5;

    // Start is called before the first frame update
    
    //BIRD DESPAWNING STUFF
    //make bird despawn (destroy function) when off camera
    //make bird despawn when hits platform/player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
   
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
        else
        {
            rb.MovePosition(rb.position + new Vector2(-1, -1) * Time.deltaTime * enemy_speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

}
