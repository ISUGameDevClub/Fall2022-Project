using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spider : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private bool isDropping = false;
    [SerializeField] private int dropSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDropping)
        {
            rb.MovePosition(transform.position += Vector3.down*dropSpeed*Time.deltaTime);
        }
            
     //   if (touching ground of player)
     //       isDropping = false;
    }


    public void spiderMoveDown()
    {
        isDropping = true;
    }
}
