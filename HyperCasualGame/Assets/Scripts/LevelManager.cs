using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject foodPrefabs;

    

    // Update is called once per frame
    void Update()
    {
        if (playerController.totalFoodEaten==3)
        {
            Debug.Log("Level Completed");
            playerController.totalFoodEaten = 0;
        }
        else if (playerController.totalFoodEaten-playerController.totalCarHitted<0)
        {
            Debug.Log("You Failed");
            playerController.totalCarHitted = 0;
            //GetComponent<BreakFruit>().Run(); //callBreakFoodAfter loosing
        }
    }
}
