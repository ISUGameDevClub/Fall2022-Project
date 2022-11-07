using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishProjectileMoveLeft : MonoBehaviour
{
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1, 0) * Time.deltaTime);
    }
}
