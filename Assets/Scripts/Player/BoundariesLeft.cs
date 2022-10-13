using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesLeft : MonoBehaviour
{
    private Vector2 screenBoundsLeft;

    // Start is called before the first frame update
    void Start()
    {
        screenBoundsLeft = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height + 0.5f, Camera.main.transform.position.z));
    }



    // Update is called once per frame
    void LateUpdate()
    {
        screenBoundsLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0.5f, Camera.main.transform.position.z));
        transform.position = new Vector3(screenBoundsLeft.x - 0.5f, screenBoundsLeft.y, 0);
    }
}
