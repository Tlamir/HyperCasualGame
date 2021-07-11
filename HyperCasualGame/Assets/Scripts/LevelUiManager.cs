using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text LevelText;
    void Start()
    {
        LevelText.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
