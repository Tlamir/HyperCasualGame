using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;//Joystick reference for assign in inspector
    [SerializeField] private float Speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;//get the horizontal value of joystick


        Vector3 translate = (new Vector3(h, 0, v) * Time.deltaTime) * Speed;
        transform.Translate(translate);
    }
}
