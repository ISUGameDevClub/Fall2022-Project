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
    void Update()
    {
        playerRB.MovePosition((Vector2)transform.position + new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y)) ;
    }
}
