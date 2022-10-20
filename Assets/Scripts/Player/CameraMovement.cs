using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private GameObject player;

    [SerializeField]
    float cameraSpeed;

    [SerializeField]
    Vector2 posOffset;

    [SerializeField]
    float maxHeightPos;

    [SerializeField]
    float minHeightPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = new Vector3(player.transform.position.x + posOffset.x, player.transform.position.y + posOffset.y, -1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //cameras current pos
        Vector3 startPos = transform.position;

        //cameras current pos
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y = (transform.position.y);
        endPos.z = -1;

        if (player.transform.position.x + posOffset.x >= transform.position.x)
        {
            transform.position = Vector3.Lerp(startPos, endPos, cameraSpeed * Time.deltaTime);
        }

        

        if (!(player.transform.position.y >= (maxHeightPos)) && !(player.transform.position.y <= (minHeightPos)))
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + posOffset.y, -1);

        }

    }
}
