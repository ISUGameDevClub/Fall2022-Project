using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermoment : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
       // playerRB = GetComponent<Rigidbody2D>;
        
    }

    // Update is called once per frame
    void Update()
    {
      
       // player2d.MovePosition((Vector)transform.position+new Vector2)(input.getarts-("horizontal")1*speed*Time.deltaTime,0));
    }
}
