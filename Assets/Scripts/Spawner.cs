using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    //SerializeField float freq; How often object will spawn
    //int time/count -variable

    public GameObject obj;
 
    [SerializeField] int time;
    [SerializeField] int freq;
    [SerializeField] int limit;
    [SerializeField] int distanceTillSpawn;
    private int spawns;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if count/time variable is divisile by freq
        //Spawn in specified object

        //To find player gameobject and its location
        if ((FindObjectOfType<PlayerMovement>().transform.position.x + distanceTillSpawn> obj.transform.position.x) && spawns<limit)
        {
            GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            spawns++;
        }

        if (Input.GetKeyDown(KeyCode.X) && spawns<limit)
        {
            GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            spawns++;
        }
        
    }
}
