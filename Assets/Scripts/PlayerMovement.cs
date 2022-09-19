using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] float speed;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerVelocity = new Vector2(Input.GetAxis("Horizontal"), 0) * Time.fixedDeltaTime * speed;
        playerRB.MovePosition(playerRB.position + playerVelocity);
    }
}
