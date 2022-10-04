using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderThwompDummy : MonoBehaviour
{

    private SpiderThwomp spiderMovement;

    // Start is called before the first frame update
    void Start()
    {
        spiderMovement = GetComponentInParent <SpiderThwomp>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spiderMovement.spiderMoveDown();
            Debug.Log("Thwomp Trigger!");
        }
    }
}
