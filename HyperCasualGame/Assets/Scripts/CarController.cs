using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float[] speeds = { 2.3f ,1.0f,5.0f,7.2f,3.1f};
    private float leftBound = -13.0f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speeds[Random.Range(0,speeds.Length)] * Time.deltaTime);
        if (transform.position.x < leftBound)
            Destroy(gameObject);

    }
   
}
