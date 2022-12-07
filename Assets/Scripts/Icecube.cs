using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecube : MonoBehaviour
{
    public EnemyHealth eh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(eh == null)
        {
            Destroy(gameObject);
        }
        else
        {

            transform.position = eh.gameObject.transform.position;
            if (eh.frozen <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
