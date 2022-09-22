using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 position = gameObject.transform.position;
            //spawn bullet here
            GameObject bullet = Instantiate( bulletPrefab, position,Quaternion.identity );
            //make bullet fly forward
        }
    }
}
