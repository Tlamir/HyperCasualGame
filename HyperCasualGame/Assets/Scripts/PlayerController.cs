using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;//Joystick reference for assign in inspector
    [SerializeField] private float Speed = 2.0f; //Player Speed
    //X Y Z values to manuplate player size 
    public float playerXincreaseRatio = 0.30f;
    public float playerYincreaseRatio = 0.001f;
    public float playerZincreaseRatio = 0.30f;
    public int totalFoodEaten=0, totalCarHitted=0;
    

    Vector3 newVector;
    FoodSpawner foodSpawner;

     void Start()
    {
        foodSpawner = GameObject.FindGameObjectWithTag("FoodSpawner").GetComponent<FoodSpawner>(); //(replace the curly brackets with the signs less than and greater than).
    }

    // Update is called once per frame
    void Update()
    {
        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;//get the horizontal value of joystick


        Vector3 translate = (new Vector3(h, 0, v) * Time.deltaTime) * Speed;
        transform.Translate(translate);
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Car")
        {
            totalCarHitted++;
            //If the player get hit by car
            //Debug.Log("Car Hitted");
            //Decrase Size
            ChangePlayerSize(playerZincreaseRatio, playerYincreaseRatio, playerYincreaseRatio, false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
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
