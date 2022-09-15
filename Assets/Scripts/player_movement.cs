using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    Rigidbody2D playerRB;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerRB.MovePosition((Vector2)transform.position + new Vector2(Input.GetAxis("Horizon")*speed*Time.deltaTime,0));
    }
}
