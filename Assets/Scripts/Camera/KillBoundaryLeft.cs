using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoundaryLeft : MonoBehaviour
{

    private Vector2 screenBoundsLeft;
    
    [SerializeField] private LayerMask layerEnemy;

    // Start is called before the first frame update
    void Start()
    {
        screenBoundsLeft = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        screenBoundsLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f));
        transform.position = new Vector3(screenBoundsLeft.x - 2.5f, screenBoundsLeft.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(collision.gameObject);
        }
    }
}