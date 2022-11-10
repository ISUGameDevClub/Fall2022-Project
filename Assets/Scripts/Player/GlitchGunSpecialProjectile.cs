using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchGunSpecialProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject dummy;
    
    // Start is called before the first frame update
    void Start()
    {
        dummy = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = dummy.transform.position;
    }
}
