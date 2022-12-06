using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator anim;
    private string newScene;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string ns)
    {
        anim.SetTrigger("Scene End");
        newScene = ns;
    }

    public void ChangeSceneEvent()
    {
        SceneManager.LoadScene(newScene);
    }

    public void RestartScene()
    {
        anim.SetTrigger("Scene End");
        newScene = SceneManager.GetActiveScene().name;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
