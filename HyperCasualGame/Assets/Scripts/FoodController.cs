using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    
    
     FoodSpawner foodSpawner;
    Vector3 r1VectorRight;

    void Start()
    {
        foodSpawner = GameObject.FindGameObjectWithTag("FoodSpawner").GetComponent<FoodSpawner> (); //(replace the curly brackets with the signs less than and greater than).
    }


  // Take this code to playerController Script
    

}
