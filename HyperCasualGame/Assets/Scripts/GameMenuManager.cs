using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    public Text LevelText;
    void Start()
    {
        LevelText.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        try
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        catch (System.Exception)
        {
            Debug.LogError("Scene Cannot be Loaded");
            
        }
    }
}
