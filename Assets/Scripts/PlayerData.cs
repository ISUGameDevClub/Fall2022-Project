using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool beatenGame;
    public int fastestSeconds;
    public int fastestMinutes;

    public PlayerData (BeatenGame bg)
    {
        beatenGame = bg.beatGame;
        fastestSeconds = bg.fastestSeconds;
        fastestMinutes = bg.fastestMinutes;
    }
}
