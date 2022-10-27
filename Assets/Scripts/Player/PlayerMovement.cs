using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    [Range(13f, 13.5f)]
    float speed;
    [SerializeField]
    [Range(14f, 14.5f)]
    public float jumpHeight;
    public int jumpsAvailable = 1;
    private int jumps = 0;
    private bool flipped = true;
    Rigidbody2D playerRB;
    [SerializeField] Animator lowerBodyAnim;
    [SerializeField] Animator upperBodyAnim;

    // Start is called before the first frame update
    void Start()
    {
        //Retrieve Components
        playerRB = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsAvailable != jumps)
        {
            playerRB.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumps++;
        }
        if (Input.GetAxisRaw("Horizontal") != 0) 
        {
            lowerBodyAnim.SetBool("walking", true);
        }
        else
        {
            lowerBodyAnim.SetBool("walking", false);
        }
        if (playerRB.velocity.y == 0) jumps = 0;

        doWeFlip();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0) * Time.fixedDeltaTime;
        playerRB.position += playerVelocity;

    }

    public bool getFlipped()
    {
        return flipped;
    }

    private void doWeFlip()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            flipped = true;
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer s in sprites)
            {
                s.flipX = false;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            flipped = false;
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer s in sprites)
            {
                s.flipX = true;
            }
        }
    }

}
