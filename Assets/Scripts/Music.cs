using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;

    public AudioSource gameMusic;
    private AudioClip newClip;
    public float musicVolume = .2f;
    public float swapSpeed = .5f;

    void Awake()
    {
        newClip = gameMusic.clip;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (gameMusic.clip != newClip)
        {
            if(gameMusic.volume > .05f)
            {
                gameMusic.volume -= Time.unscaledDeltaTime * swapSpeed;
            }
            else
            {
                gameMusic.volume = 0;
                gameMusic.clip = newClip;
                gameMusic.Play();
            }
        }
        else
        {
            if (gameMusic.volume < musicVolume)
            {
                gameMusic.volume += Time.unscaledDeltaTime * swapSpeed;
            }
            else
            {
                gameMusic.volume = musicVolume;
            }
        }
    }

    public void ChangeSong(AudioClip clip)
    {
        newClip = clip;
    }
}
