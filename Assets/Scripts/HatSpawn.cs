using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatSpawn : MonoBehaviour
{
    public GameObject[] hats;
    public GameObject myHat;
    public float hatSpawnMinTime;
    public float hatSpawnMaxTime;

    private bool spawningHat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myHat == null && !spawningHat)
        {
            spawningHat = true;
            StartCoroutine(SpawnHatEnum());
        }
    }

    private IEnumerator SpawnHatEnum()
    {
        yield return new WaitForSeconds(Random.Range(hatSpawnMinTime, hatSpawnMaxTime));
        myHat = Instantiate(hats[Random.Range(0, hats.Length)], (Vector2)transform.position + Vector2.up, Quaternion.identity);
        spawningHat = false;
    }
}
