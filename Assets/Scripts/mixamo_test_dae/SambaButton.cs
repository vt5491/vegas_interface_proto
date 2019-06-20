using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
public class SambaButton : MonoBehaviour
{
    private GameObject anim_go;
    // private Animation animation;
    private Animator animator;
    void Start()
    {
        anim_go = GameObject.Find("bigvegas");
        animator = anim_go.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnButtonDown() {
    // private void OnButtonIsPressed() {
    public void OnButtonIsPressed(Hand hand) {
        Debug.Log("SambaButton: button pressed");
    }
    // public void OnButtonDown(Hand hand) {
    public void OnButtonDown(Hand fromHand)
    {
        Debug.Log("SambaButton.OnButtonDown: button pressed");
        // animator.Play("Base Layer.Run");
        animator.Play("Base Layer.bellyDance");

    }
}
