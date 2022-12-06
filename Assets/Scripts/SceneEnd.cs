using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnd : MonoBehaviour
{
    public string nextScene;
    public AudioClip changeToSong;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<SceneTransition>().ChangeScene(nextScene);
            if(changeToSong != null)
                FindObjectOfType<Music>().ChangeSong(changeToSong);
        }
    }
}
