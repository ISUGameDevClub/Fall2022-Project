using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesRight : MonoBehaviour
{

    private Vector2 screenBoundsRight;
    // Start is called before the first frame update
    void Start()
    {
        screenBoundsRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height + 0.5f, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        screenBoundsRight = Camera.main.ScreenToWorldPoint(new Vector3(1, 0.5f, 0));
        transform.position = new Vector3(screenBoundsRight.x + 0.5f, screenBoundsRight.y, 0);
    }
}
