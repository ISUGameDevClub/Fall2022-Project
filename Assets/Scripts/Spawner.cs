using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
 
    //Serialized Variables, these should make sense, if you have a question ask Bart (xaxa#5069)
    [SerializeField] int frequency;
    [SerializeField] int limitOfSpawn;
    [SerializeField] int distanceTillSpawn;
    [SerializeField] bool unlimitedSpawn;

    //Private Variables, Spawns checks how many spawns, time is added once per second, post is position of player
    private int spawns;
    private int time;
    private float post;

    

    void Start()
    {
        //Using a unity method Invoke repeating to call the UpdateTime function every 1 second.
        //This function is below the Update() function.
        StartCoroutine("UpdateTime");

        //Calling the position of the player to a float variable in start since we can only
        //get the position of the player once the game is started.
        post = FindObjectOfType<PlayerMovement>().transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //This code below is how you spawn in a game object.
        //GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);

        if (unlimitedSpawn == true && frequency == 0)
        {
            if (post + distanceTillSpawn > obj.transform.position.x)
            {
                GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            }
        } else if (unlimitedSpawn == true && frequency > 0)
        {
            if (frequency == time && post + distanceTillSpawn > obj.transform.position.x)
            {
                GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
                time = 0;
            }
        } else if (unlimitedSpawn == false && frequency == 0)
        {
            if (spawns < limitOfSpawn && post + distanceTillSpawn > obj.transform.position.x)
            {
                GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
                spawns++;
            }
        } else if (unlimitedSpawn == false && frequency > 0)
        {
            if (spawns < limitOfSpawn && frequency == time && post + distanceTillSpawn > obj.transform.position.x)
            {
                GameObject spawner = (GameObject)Instantiate(obj, transform.position, transform.rotation);
                spawns++;
                time = 0;
            }
        }
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
