using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SpiderThwomp : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isDropping;
    private bool stop;
    private bool raise;
    [SerializeField] GameObject webby;
    [SerializeField] GameObject webbyBase;
    [SerializeField] Animator anim;
    [SerializeField] private int dropSpeed = 3;
    [SerializeField] private int raiseSpeed = 3;
    [SerializeField] private float maxDistance = 1;
    [SerializeField] private float restTime = 3;
    private float yPos;
    [SerializeField] private LayerMask layerHitGround;

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        isDropping = false;
        rb = GetComponent<Rigidbody2D>();
        yPos = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        webby.transform.position = new Vector3(webby.transform.position.x, (webbyBase.transform.position.y + .75f) + (((transform.position.y + .23f) - (webbyBase.transform.position.y + .75f)) /2), webby.transform.position.z);
        webby.transform.localScale = new Vector3(webby.transform.localScale.x, Vector2.Distance(webbyBase.transform.position + new Vector3(0, .75f, 0), transform.position + new Vector3(0, .23f, 0)), webby.transform.localScale.z);
        if (!stop && isDropping)
        {
            anim.SetTrigger("fall");
            rb.MovePosition(transform.position += Vector3.down * dropSpeed * Time.deltaTime);

            if (Physics2D.Raycast(transform.position, -transform.up, maxDistance, layerHitGround))
                {
                    stop = true;
                    anim.SetTrigger("idle");
                    StartCoroutine(rise());
                }
        }
        
        if (raise)
        {
            anim.SetTrigger("climb");
            rb.MovePosition(transform.position += Vector3.up * raiseSpeed * Time.deltaTime);
            if (transform.position.y >= yPos)
            {
                anim.SetTrigger("idle");
                raise = false;
                stop = false;
                isDropping = false;
            }
        }
    }


    public void spiderMoveDown()
    {
        isDropping = true;
    }



    private IEnumerator rise()
    {
        yield return new WaitForSeconds(restTime);
        raise = true;
    }

    


}
