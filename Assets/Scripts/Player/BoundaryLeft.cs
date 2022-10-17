using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryLeft : MonoBehaviour
{

    private Vector2 screenBoundsLeft;

    // Start is called before the first frame update
    void Start()
    {
        screenBoundsLeft = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        screenBoundsLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 1));
        transform.position = new Vector3(screenBoundsLeft.x - 0.5f, screenBoundsLeft.y, 0);
    }
}
