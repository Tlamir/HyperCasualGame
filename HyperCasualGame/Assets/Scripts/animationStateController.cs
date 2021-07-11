using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void walking()
    {
        animator.SetBool("isWalking", true);
    }

    public void notwWalking()
    {
        animator.SetBool("isWalking", false);
    }

    public void startDance()
    {
        animator.SetBool("isFinished", true);
    }

    public void startTurn()
    {
        animator.SetBool("isTurning", true);
    }
    public void endTurn()
    {
        animator.SetBool("isTurning", false);
    }

}
