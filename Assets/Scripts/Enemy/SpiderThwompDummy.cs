using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderThwompDummy : MonoBehaviour
{

    [SerializeField] SpiderThwomp spiderMovement;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spiderMovement.spiderMoveDown();
        }
    }
}
