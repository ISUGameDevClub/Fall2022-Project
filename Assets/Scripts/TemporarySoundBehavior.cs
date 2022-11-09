using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarySoundBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource AudS = GetComponent<AudioSource>();
        Destroy(gameObject, AudS.clip.length);
    }
}
