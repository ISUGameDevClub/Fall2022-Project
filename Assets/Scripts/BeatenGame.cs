using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeatenGame : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public bool beatGame;
    public int fastestSeconds;
    public int fastestMinutes;
    public bool checkIfGameBeaten;

    public void BeatGame()
    {
        LoadPlayer();
        beatGame = true;

        if((fastestMinutes == 0 && fastestSeconds == 0) || Timer.minutes <= fastestMinutes)
        {
            if((fastestMinutes == 0 && fastestSeconds == 0) || Timer.minutes < fastestMinutes || Timer.seconds < fastestSeconds)
            {
                fastestMinutes = Timer.minutes;
                fastestSeconds = Mathf.RoundToInt(Timer.seconds);
            }
        }

        SaveSystem.SavePlayerData(this);
    }

    public void ResetGame()
    {
        beatGame = false;
        fastestSeconds = 0;
        fastestMinutes = 0;

        SaveSystem.SavePlayerData(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadData();

        if (data != null)
        {
            beatGame = data.beatenGame;
            fastestSeconds = data.fastestSeconds;
            fastestMinutes = data.fastestMinutes;
        }
    }

    private void Start()
    {
        if(checkIfGameBeaten)
        {
            LoadPlayer();
            if (!beatGame)
                Destroy(gameObject);
            else
            {
                if (Mathf.RoundToInt(fastestSeconds) > 9)
                    timer.text = fastestMinutes.ToString("F0") + ":" + Mathf.RoundToInt(fastestSeconds).ToString("F0");
                else
                    timer.text = fastestMinutes.ToString("F0") + ":" + "0" + Mathf.RoundToInt(fastestSeconds).ToString("F0");
            }
        }
    }
}
