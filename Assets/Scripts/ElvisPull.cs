using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElvisPull : StateMachineBehaviour
{
    private GameObject gm;
    // private int abc;
    private LazySusan2 ls;
    private void Awake() {
        Debug.Log("ElvisPull.Awake: entered");
        gm = GameObject.Find("GameMaster");
        Debug.Log($"ElvisPull.Awake: gm={gm}");
        ls = GameObject.Find("lv_aggregate").GetComponent<LazySusan2>();
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("vt:ElvisPull: OnStateEnter: IsTag.ls_anim={stateInfo.IsTag("ls_anim")}");
        // Debug.Log($"OnStateEnter: IsTag.ls_anim={stateInfo.IsTag("ls_anim")}");
        // Debug.Log($"OnStateEnter: IsName.ls_001_anim={stateInfo.IsName("ls_001_anim")}");
        // if (stateInfo.IsName("idle"))
        // {
        //     GameObject bigvegasGo = GameObject.Find("bigvegas");
        //     // bigelvisGo.Init
        //     BigVegasBehavior bigVegasBehavior = bigvegasGo.GetComponent(typeof(BigVegasBehavior)) as BigVegasBehavior;
        //     // To be safe, reset YRot each time as animations and reverse
        //     // animations are not always perfect un-doings and you can have
        //     // "leftover" rotations.
        //     // bigVegasBehavior.resetYRot();
        //     bigvegasGo.transform.eulerAngles = new Vector3(bigvegasGo.transform.eulerAngles.x, 180f, bigvegasGo.transform.eulerAngles.z);
        // }
        if (stateInfo.IsName("rev_stand_to_freehang"))
        {
            // animator.Play("lever_pull");
            GameObject leverPullGo = GameObject.Find("lever_pull");
            Animator leverPullAnim = leverPullGo.GetComponent<Animator>();

            //vt-xleverPullAnim.gameObject.transform.Rotate(0, 90.0f, 0, Space.Self);
            // Rotate(xAngle, yAngle, zAngle, Space.Self);
            leverPullAnim.Play("pull_lever");
            // GameObject gm = GameObject.Find("GameMaster");
            // gm.SendMessage("LazySusanBtnClicked", btnPressed);
            gm.SendMessage("LazySusanRotate");
        }

        if (stateInfo.IsTag("ls_tgt_state")) {
            float nextOffset = ls.anim.GetInteger("ls_state") * 0.25f; 
            Debug.Log($"ElvisPull.OnStateEnter: nextOffset={nextOffset}");
            ls.anim.SetFloat("ls_offset", nextOffset);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     if(stateInfo.IsName("slot_0_to_slot_1"))
    //         Debug.Log($"OnStateUpdate: stateInfo.normalizedTime={stateInfo.normalizedTime}");
    //     if(stateInfo.IsTag("ls_anim")) {

    //     }
       
    // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log($"OnStateExit: IsTag.ls_anim={stateInfo.IsTag("ls_anim")}");
        // if (stateInfo.IsTag("ls_anim"))
        // {
        //     // GameObject bigvegasGo = GameObject.Find("bigvegas");
        //     // bigelvisGo.Init
        //     // BigVegasBehavior bigVegasBehavior = bigvegasGo.GetComponent(typeof(BigVegasBehavior)) as BigVegasBehavior;
        //     // To be safe, reset YRot each time as animations and reverse
        //     // animations are not always perfect un-doings and you can have
        //     // "leftover" rotations.
        //     // Debug.Log("ElvisPull.OnStateExit: now resetting y-rot");
        //     // bigVegasBehavior.resetYRot();
        //     Debug.Log($"OnStateExit: sending LazySusanAnimDone");
        //     gm.SendMessage("LazySusanAnimDone");
        // }
        if (stateInfo.IsTag("ls_anim"))
        {
            Debug.Log($"OnStateExit: sending LazySusanAnimDone");
            gm.SendMessage("LazySusanAnimDone");
        }
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    // override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //    // Implement code that processes and affects root motion
    //     if (stateInfo.IsTag("ls_anim"))
    //     {
    //         Debug.Log($"OnStateExit: sending LazySusanAnimDone");
    //         gm.SendMessage("LazySusanAnimDone");
    //     }
    // }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
