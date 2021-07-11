using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;

    
    public float MoveFactorX => _moveFactorX;
    public float zPosMin = -4.68f, zPosMax = 14.9f;
    public PlayerController playerController;
    animationStateController animationStateController;

    [SerializeField] private float Speed = 2.0f; //Player Speed

    private void Start()
    {
        animationStateController = GameObject.FindGameObjectWithTag("Player").GetComponent<animationStateController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;

            animationStateController.walking();
            MovePlayer();
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
            animationStateController.notwWalking();
        }
    }




    public void MovePlayer()
    {
        if (!playerController.isLevelFinished)
        {
            Vector3 translate = (new Vector3(0, 0, 1) * Time.deltaTime) * Speed;
            transform.Translate(translate);
            //    //Limit player movment in z axis
            float zPos = Mathf.Clamp(transform.position.z, zPosMin, zPosMax);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
        
    }
}
