using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDummy : MonoBehaviour
{
    private Spider spiderMovement;
    // Start is called before the first frame update
    void Start()
    {
        spiderMovement = GetComponentInParent<Spider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spiderMovement.spiderMoveDown();
        }
    }

}
