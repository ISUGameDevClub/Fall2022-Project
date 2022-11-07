using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMelee : MonoBehaviour
{

    public GameObject dogMel;
    public float cooldown;
    public bool stab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        
        if (cooldown <= 0.0f)
        {
            GameObject mel = Instantiate(dogMel, transform);
            
            if(transform.localScale.x == 1)
            {
                mel.transform.localPosition = new Vector2(-1, 0);
            }
            else
            {
                mel.transform.localPosition = new Vector2(-1, 0);
            }
            GameObject.Destroy(mel, 1.0f);
            stab = true;
            cooldown = 2.0f;
        }
    }
}
