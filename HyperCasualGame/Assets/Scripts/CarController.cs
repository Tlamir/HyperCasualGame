using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed;
    [SerializeField]
    public float[] speeds = { 1.0f, 2.3f, 5.0f,7.2f,3.1f,0.05f,9f};
    private float leftBound = -13.0f;

    void Start()
    {
        speed = speeds[Random.Range(0, speeds.Length)];
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.x < leftBound)
            Destroy(gameObject);
    }
}
