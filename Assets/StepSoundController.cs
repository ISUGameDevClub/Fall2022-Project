using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSoundController : MonoBehaviour
{
    PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = transform.parent.GetComponent<PlayerMovement>();
    }
    public void Step()
    {
        pm.StepSound();
    }
}
