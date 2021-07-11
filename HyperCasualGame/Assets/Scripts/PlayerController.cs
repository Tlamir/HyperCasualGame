using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //X Y Z values to manuplate player size 
    public float playerXincreaseRatio = 0.30f;
    public float playerYincreaseRatio = 0.001f;
    public float playerZincreaseRatio = 0.30f;
    public float minX = -5.0f, maxX = 5.0f;
    public int totalFoodEaten=0, totalCarHitted=0;
    private int inverseControls = 1;//1 not rotated -1 is rotated
   
   

    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    public bool isLevelFinished = false;
    



    Vector3 newVector;
    FoodSpawner foodSpawner;
    ProgressBar progressBar;

    void Start()
    {
        foodSpawner = GameObject.FindGameObjectWithTag("FoodSpawner").GetComponent<FoodSpawner>();
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBar>();
        _swerveInputSystem = GetComponent<SwerveInputSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLevelFinished)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount*inverseControls, 0, 0);
            //Limit player movment in x axis
            float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Car")
        {
            totalCarHitted++;
            //If the player get hit by deer
            //Decrase Size
            ChangePlayerSize(playerZincreaseRatio, playerYincreaseRatio, playerYincreaseRatio, false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            //Increase progress and rotate player
            progressBar.IncrementProgress();
            gameObject.transform.Rotate(0,180,0);
            //swap movment
            inverseControls *= -1;
            totalFoodEaten++;
            //Increase player size here
            ChangePlayerSize(playerZincreaseRatio, playerYincreaseRatio, playerYincreaseRatio,true);
            foodSpawner.SpawnRandomFood();
            Destroy(other.gameObject);
        }
        
    }

    public void ChangePlayerSize(float x,float y ,float z,bool IsItIncrease)
    {
        if (IsItIncrease)
        {
            newVector = new Vector3(gameObject.transform.localScale.x + playerXincreaseRatio, gameObject.transform.localScale.y + playerYincreaseRatio, gameObject.transform.localScale.z + playerZincreaseRatio);
            gameObject.transform.localScale = newVector;
        }
        else
        {
            newVector = new Vector3(gameObject.transform.localScale.x - playerXincreaseRatio, gameObject.transform.localScale.y - playerYincreaseRatio, gameObject.transform.localScale.z - playerZincreaseRatio);
            gameObject.transform.localScale = newVector;
        }
        
    }

    
}
