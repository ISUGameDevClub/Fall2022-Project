using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    [Range(1,15)]
    float speed;
    public float jumpHeight;
    public int jumpsAvailable = 1; 
    private int jumps = 0;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        //Retrieve Components
        playerRB = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpsAvailable != jumps) 
        {
            playerRB.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumps++;
        }


        if (playerRB.velocity.y == 0) jumps = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0) * Time.fixedDeltaTime;
        playerRB.position += playerVelocity;
    }
}
