using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Ray ray;
    // Start is called before the first frame update
    void Awake()
    {
        //Vector2 range = new Vector2(-20, 0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FireRay()
    {
        ray = new Ray(transform.position, transform.forward * 10);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 10))
        {
            Debug.Log("Hit ray");
            //work in progress
        }
    }

}
