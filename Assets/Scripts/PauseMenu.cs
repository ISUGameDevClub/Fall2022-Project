using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    public AudioClip titleMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (!FindObjectOfType<LMPManager>())
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            Time.timeScale = 0;
        }

        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnpauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToTitle(string titleName)
    {
        UnpauseGame();
        if(FindObjectOfType<Music>() != null)
        {
            FindObjectOfType<Music>().ChangeSong(titleMusic);
        }
        FindObjectOfType<SceneTransition>().ChangeScene(titleName);        
    }

    public void RestartLevel()
    {
        UnpauseGame();
        FindObjectOfType<SceneTransition>().RestartScene();
    }
}
