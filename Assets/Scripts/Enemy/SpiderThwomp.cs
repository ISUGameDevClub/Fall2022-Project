using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpiderThwomp : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private bool isDropping;
    [SerializeField] private bool stop;
    private bool raise;
    [SerializeField] private int dropSpeed = 3;
    [SerializeField] private int raiseSpeed = 3;
    [SerializeField] private float maxDistance = 1;
    [SerializeField] private float restTime = 3;
    private float yPos;
    [SerializeField] private LayerMask layerHit;

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

        if (!stop && isDropping)
        {
            rb.MovePosition(transform.position += Vector3.down * dropSpeed * Time.deltaTime);

            if (Physics2D.Raycast(transform.position, -transform.up, maxDistance, layerHit))
                {
                    stop = true;
                    
                    StartCoroutine(rise());
                }
        }
        
        if (raise)
        {
            rb.MovePosition(transform.position += Vector3.up * raiseSpeed * Time.deltaTime);
            if (transform.position.y >= yPos)
            {
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


    IEnumerator rise()
    {
        yield return new WaitForSeconds(restTime);
        raise = true;
    }


}
