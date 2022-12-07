using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool p2;
    [SerializeField]
    GameObject
        jumpPrefab;
    [SerializeField]
    GameObject
        stepPrefab;
    [SerializeField]
    [Range(13f, 13.5f)]
    float
        speed;
    [SerializeField]
    [Range(14f, 14.5f)]
        public float jumpHeight;
        private bool flipped = true;
        Rigidbody2D playerRB;
    [SerializeField]
    [Range(1.2f,3f)]
    float
        coyoteTime;
    [SerializeField] 
    Animator 
        lowerBodyAnim;
    [SerializeField] 
    Animator 
        upperBodyAnim;

    private bool grounded;



    // Start is called before the first frame update
    void Start()
    {
        //Retrieve Components
        playerRB = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        

        if (((Input.GetKeyDown(KeyCode.Space) && !p2) || (Input.GetKeyDown(KeyCode.I) && p2)) && grounded && !((Input.GetKey(KeyCode.LeftShift) && !p2) || (Input.GetKeyDown(KeyCode.RightShift) && p2)) && Time.timeScale!=0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            Instantiate(jumpPrefab, transform.position, Quaternion.identity);

        }

        if (((Input.GetAxisRaw("Horizontal") != 0 && !p2) || (Input.GetAxisRaw("Horizontal2") != 0 && p2)) && !(((Input.GetKey(KeyCode.LeftShift) && !p2) || (Input.GetKeyDown(KeyCode.RightShift) && p2)) && grounded) && Time.timeScale != 0) 
        {
            lowerBodyAnim.SetBool("walking", true);
        }
        else
        {
            lowerBodyAnim.SetBool("walking", false);
        }

        LayerMask masks = LayerMask.GetMask("Ground", "One Way Ground");
        RaycastHit2D hit = Physics2D.CircleCast(transform.position,.3f, Vector2.down, 1.1f, masks);
        if (hit.collider != null && (LayerMask.LayerToName(hit.collider.gameObject.layer) == "Ground" || LayerMask.LayerToName(hit.collider.gameObject.layer) == "One Way Ground"))
        {
            if (playerRB.velocity.y <= 0)
            {
                grounded = true;
            }
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
            
        }
        else
        {
            grounded = false;
        }

        doWeFlip();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(((Input.GetKey(KeyCode.LeftShift) && !p2) || (Input.GetKeyDown(KeyCode.RightShift) && p2)) && grounded) && Time.timeScale != 0)
        {
            Vector2 playerVelocity;
            if (!p2)
                playerVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0) * Time.fixedDeltaTime;
            else
                playerVelocity = new Vector2(Input.GetAxis("Horizontal2") * speed, 0) * Time.fixedDeltaTime;
            playerRB.position += playerVelocity;
        }
        if(playerRB.velocity.y > 0)
        {
            if (((Input.GetKey(KeyCode.Space) && !p2) || (Input.GetKey(KeyCode.I) && p2)) && Time.timeScale != 0)
            {
                playerRB.gravityScale = 2.4f;
            }
            else
            {
                playerRB.gravityScale = 4.8f;
            }
        }
        else
        {
            playerRB.gravityScale = 4.8f;
        }
    }

    public bool getFlipped()
    {
        return flipped;
    }
    public void StepSound()
    {
        if (grounded)
        {
            Instantiate(stepPrefab, transform.position, Quaternion.identity);
        }
    }
    private void doWeFlip()
    {
        if (((Input.GetAxisRaw("Horizontal") == 1 && !p2) || (Input.GetAxisRaw("Horizontal2") == 1 && p2)) && Time.timeScale != 0)
        {
            flipped = true;
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer s in sprites)
            {
                s.flipX = false;
            }
        }
        else if (((Input.GetAxisRaw("Horizontal") == -1 && !p2) || (Input.GetAxisRaw("Horizontal2") == -1 && p2)) && Time.timeScale != 0)
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
