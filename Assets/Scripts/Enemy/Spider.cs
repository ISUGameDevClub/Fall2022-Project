using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class Spider : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] private bool isDropping;
    [SerializeField] private bool stop;
    [SerializeField] private int dropSpeed;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerHit;

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        isDropping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!stop && isDropping)
        {
            anim.SetTrigger("fall");
            rb.MovePosition(transform.position += Vector3.down * dropSpeed * Time.deltaTime);
        }

        if (Physics2D.Raycast(transform.position, -transform.up, maxDistance, layerHit))
        {
            anim.SetTrigger("idle");
            stop = true;
        }
        //   if (touching ground or player)
        //       isDropping = false;
    }


    public void spiderMoveDown()
    {
        isDropping = true;
    }

}
