using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //X Y Z values to manuplate player size 
    public float playerXincreaseRatio = 0.30f;
    public float playerYincreaseRatio = 0.001f;
    public float playerZincreaseRatio = 0.30f;
    public float minX = -3.2F, maxX = 3.34f;
    public int totalFoodEaten=0, totalCarHitted=0;
   

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
            transform.Translate(swerveAmount, 0, 0);
        }
        
        //float xPos = Mathf.Clamp(transform.position.z, minX, minX);

        //transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

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
            progressBar.IncrementProgress();
            gameObject.transform.Rotate(0,180,0);
            totalFoodEaten++;
            //Increase player size here
            ChangePlayerSize(playerZincreaseRatio, playerYincreaseRatio, playerYincreaseRatio,true);
            foodSpawner.SpawnRandomFood();
            Destroy(other.gameObject);
            //Debug.Log(totalFoodEaten);
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
