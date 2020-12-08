using UnityEngine;
using System.Collections;

public class ContinuityAttackBehaviour : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("MoveForward", false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Hikick", true);
            Debug.Log("dd");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Hikick", false);
    }
}
