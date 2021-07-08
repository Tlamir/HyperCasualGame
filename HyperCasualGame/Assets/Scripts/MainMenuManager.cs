using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    private string[] scenePaths;
  
    public void StartButton()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
