using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetter : MonoBehaviour
{

    public void ChangeSceneSong(AudioClip changeToSong)
    {
        if (changeToSong != null)
            FindObjectOfType<Music>().ChangeSong(changeToSong);
    }
}
