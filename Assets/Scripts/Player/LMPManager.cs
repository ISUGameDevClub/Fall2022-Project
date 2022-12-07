using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LMPManager : MonoBehaviour
{
    public int P1P;
    public TextMeshProUGUI p1s;
    public int P2P;
    public TextMeshProUGUI p2s;
    public TextMeshProUGUI vt;

    public AudioClip titleSong;

    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PauseMenu>().PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        p1s.text = P1P.ToString();
        p2s.text = P2P.ToString();

        if (!gameOver)
        {
            if (P1P >= 10)
            {
                gameOver = true;
                vt.text = "Player 1 Wins!";
                vt.color = new Color(.2f, .2f, 1, 1);
                StartCoroutine(EndGame());
            }
            else if (P2P >= 10)
            {
                gameOver = true;
                vt.text = "Player 2 Wins!";
                vt.color = new Color(1, .2f, .2f, 1);
                StartCoroutine(EndGame());
            }
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<SceneTransition>().ChangeScene("0. Title");

        if(FindObjectOfType<Music>() != null)
        {
            FindObjectOfType<Music>().ChangeSong(titleSong);
        }
    }
}
