using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MAINMENU : MonoBehaviour
{
    public string sceneLoad;
    // Start is called before the first frame update
   
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneLoad); 
    }
    // Update is called once per frame
    
}
