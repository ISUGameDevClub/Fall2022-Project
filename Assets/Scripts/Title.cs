using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    public GameObject timerStuff;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        if(Timer.seconds != 0 || Timer.minutes != 0)
        {
            timerStuff.SetActive(true);
            if (Mathf.RoundToInt(Timer.seconds) > 9)
                timerText.text = Timer.minutes.ToString("F0") + ":" + Mathf.RoundToInt(Timer.seconds).ToString("F0");
            else
                timerText.text = Timer.minutes.ToString("F0") + ":" + "0" + Mathf.RoundToInt(Timer.seconds).ToString("F0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
