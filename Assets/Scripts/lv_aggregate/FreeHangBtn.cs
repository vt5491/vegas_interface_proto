using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeHangBtn : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GameObject.Find("bigvegas").GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnClick() {
        Debug.Log("FreeHangBtn.OnClick: entered");
    }

    private void DoIt() {
        Debug.Log("FreeHangBtn.DoIt: entered");
    }

    private void PlayFreeHangAnimation() {
        // animator.Play("Base Layer.standToFreeHang");
        animator.Play("Base Layer.LeverPull");
    }
}
