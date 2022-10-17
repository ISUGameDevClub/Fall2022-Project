using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private GameObject player;

    [SerializeField]
    float cameraSpeed;
    
    [SerializeField]
    bool useCameraStartPos;
    
    [SerializeField]
    Vector2 cameraStartPos;

    Vector3 startPos;

    [SerializeField]
    Vector2 posOffset;

    [SerializeField]
    float minX;

    [SerializeField]
    float maxX;

    [SerializeField]
    float minY;

    [SerializeField]
    float maxY;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(cameraStartPos.x, cameraStartPos.y, -1);
        player = GameObject.Find("Player");

        if (useCameraStartPos)
            transform.position = startPos;

        else
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
        endPos.y += posOffset.y;
        endPos.z = -1;

        if (endPos.x <= minX)
            endPos.x = minX;

        if (endPos.x >= maxX)
            endPos.x = maxX;

        if (player.transform.position.x + posOffset.x < transform.position.x)
        {
            endPos.x = transform.position.x;
        }

        if (endPos.y <= minY)
            endPos.y = minY;

        if (endPos.y >= maxY)
            endPos.y = maxY;
       
        transform.position = Vector3.Lerp(startPos, endPos, cameraSpeed * Time.deltaTime);
        


    }
}
