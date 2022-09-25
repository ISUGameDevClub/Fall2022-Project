using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
 
    [SerializeField] int freq;
    [SerializeField] int limit;
    [SerializeField] int distanceTillSpawn;
    [SerializeField] bool unlimited;

    private int spawns;
    private int time;
    private float pos;
    private float spawnerPos;
    private bool init;

    //Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //Player Position and Spawner position are assaigned to corresponsing variables
        pos = FindObjectOfType<PlayerMovement>().transform.position.x;
        spawnerPos = transform.position.x;

        //If X value of player in addition to the specified distance is greater than the spawners position, Initialize the spawner
        if (pos + distanceTillSpawn> spawnerPos)
        { 
            if (!init) //Used to only initialize the spawner once
            {
                //Using a unity method Invoke repeating to call the UpdateTime function every 1 second.
                //UpdateTime() function is below the Update() function.
                InvokeRepeating("UpdateTime", 1f, 1f);
                GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
                spawns++;
            }
            init = true;
        }

        //Actual Spawning process
        if(init && time != 0 && time % freq == 0 && unlimited)
        {
            GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            time = 0;
            spawns++;
        }
        else if(init && time != 0 && time % freq == 0 && spawns<limit)
        {
            GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            time = 0;
            spawns++;
        }
       
        //To do something when key pressed if (Input.GetKeyDown(KeyCode.X))
    }

    void UpdateTime()
    {
        //Updating the time variable every second by using InvokeRepeating in start method.
        time++;
    }

}
