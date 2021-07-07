using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    
    public float playerXincreaseRatio = 0.30f;
    public float playerYincreaseRatio = 0.001f;
    public float playerZincreaseRatio = 0.30f;
     FoodSpawner foodSpawner;
    Vector3 r1VectorRight;

    void Start()
    {
        foodSpawner = GameObject.FindGameObjectWithTag("FoodSpawner").GetComponent<FoodSpawner> (); //(replace the curly brackets with the signs less than and greater than).
    }


  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increase size Here
            r1VectorRight = new Vector3(other.transform.localScale.x+ playerXincreaseRatio, other.transform.localScale.y+ playerYincreaseRatio, other.transform.localScale.z+ playerZincreaseRatio);
            other.transform.localScale = r1VectorRight;

            if (other.gameObject.transform.position.z > 12)
            {
               
                //Spawn in bottom
                foodSpawner.SpawnRandomFoodBottom();

            }
            else
            {
                //Spawn in top
                foodSpawner.SpawnRandomFoodTop();
            }
            Destroy(gameObject);

        }
    }

}
