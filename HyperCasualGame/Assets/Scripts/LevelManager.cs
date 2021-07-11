using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public PlayerController playerController;
    public Text FailedText;
    public Button ReturnToMenuButton;
    public Button NextLevelButton;
    public AudioSource playSound;

    animationStateController animationStateController;

    void Start()
    {
       animationStateController = GameObject.FindGameObjectWithTag("Player").GetComponent<animationStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Total food to finish level = levelNumber+2
        if (playerController.totalFoodEaten== SceneManager.GetActiveScene().buildIndex + 2)
        {
            playerController.totalFoodEaten = 0;
            FailedText.text="Succes";
            FailedText.color = Color.green;
            FailedText.gameObject.SetActive(true);
            //ReturnToMenuButton.gameObject.SetActive(true);
            NextLevelButton.gameObject.SetActive(true);
            animationStateController.startDance();
            playerController.isLevelFinished = true;
        }
        else if (playerController.totalFoodEaten-playerController.totalCarHitted<0) //Player looses
        {
            playSound.Play();
            playerController.totalCarHitted = 0;
            playerController.isLevelFinished = true;
            FailedText.gameObject.SetActive(true);
            ReturnToMenuButton.gameObject.SetActive(true);
        }
    }
}
