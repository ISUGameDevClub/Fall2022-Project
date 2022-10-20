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

    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine("UpdateTime");
    }

    // Update is called once per frame
    void Update()
    {
        //Player Position and Spawner position are assaigned to corresponsing variables
        pos = FindObjectOfType<PlayerMovement>().transform.position.x;
        spawnerPos = transform.position.x;

        //Actual Spawning process
        if (pos + distanceTillSpawn > spawnerPos && time != 0 && time % freq == 0 && unlimited)
        {
            GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            time = 0;
            spawns++;
        }
        else if (pos + distanceTillSpawn > spawnerPos && time != 0 && time % freq == 0 && spawns < limit)
        {
            GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            time = 0;
            spawns++;
        }

        //To do something when key pressed if (Input.GetKeyDown(KeyCode.X))
    }
    IEnumerator UpdateTime()
    {
        while (true) // this just equates to "repeat forever"
        {
            yield return new WaitForSeconds(1f); // "pauses" for 1 second.. note, the actual game doesn't pause..
            time++; //increases time by 1
        }
    }

}