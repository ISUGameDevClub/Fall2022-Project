using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] GameObject[] layers;
    [SerializeField] float[] speeds;

    private void Update()
    {
        for(int i = 0; i<layers.Length; i++)
        {
            layers[i].transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speeds[i], 0, 0));
        }
    }
}
