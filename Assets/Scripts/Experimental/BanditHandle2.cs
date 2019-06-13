using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Valve.VR.InteractionSystem;
public class BanditHandle2 : MonoBehaviour
{
    private float angularVel = 90.0f;
    private Interactable interactable;
    private Vector3 oldPosition;
    private Quaternion oldRotation;
    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);
    private Vector3 initPos;
    private Quaternion initRot;
    private LinearMapping lm;
    private CircularDrive circDrive;
    void Awake()
    {
        interactable = this.GetComponent<Interactable>();
        initPos = transform.position;
        initRot = transform.rotation;
    }

    void Start() {
        GameObject guitaristText = GameObject.Find("GuitaristText");
        // TextMeshPro mText = guitaristText.GetComponent<TextMeshPro>();
        TextMeshProUGUI mText = guitaristText.GetComponent<TextMeshProUGUI>();
        mText.text = "Eric Clapton";

        lm = GameObject.Find("bh2LinearMapping").GetComponent<LinearMapping>();

        circDrive = GetComponent<CircularDrive>();
        
    }
    void Update() {
        // transform.RotateAround(transform.position, Vector3.right, deltaTheta);
        // transform.RotateAround(transform.position, Vector3.right, Time.deltaTime * angularVel);
    }
  
    // private void HandHoverUpdate(Hand hand)
    // {
    //     Debug.Log("BH2.HandHoverUpdate: entered");
    //     GrabTypes startingGrabType = hand.GetGrabStarting();
    //     bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

    //     if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
    //     {
    //         // Save our position/rotation so that we can restore it when we detach
    //         oldPosition = transform.position;
    //         oldRotation = transform.rotation;

    //         // Call this to continue receiving HandHoverUpdate messages,
    //         // and prevent the hand from hovering over anything else
    //         hand.HoverLock(interactable);

    //         // Attach this object to the hand
    //         hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
    //     }
    //     else if (isGrabEnding)
    //     {
    //         // Detach this object from the hand
    //         hand.DetachObject(gameObject);

    //         // Call this to undo HoverLock
    //         hand.HoverUnlock(interactable);

    //         // Restore position/rotation
    //         transform.position = oldPosition;
    //         transform.rotation = oldRotation;
    //     }
    // }
    // private void HandHoverUpdate(Hand hand)
    // {
    //     // Debug.Log("BH2.HandHoverUpdate: entered");
    //     bool isGrabEnding = hand.IsGrabEnding(this.gameObject);
    //     if (isGrabEnding)
    //     {
    //         // // Detach this object from the hand
    //         // hand.DetachObject(gameObject);

    //         // // Call this to undo HoverLock
    //         // hand.HoverUnlock(interactable);

    //         // Restore position/rotation
    //         transform.position = initPos;
    //         transform.rotation = initRot;
    //     }
    // }

    // private void onDetachedFromHand() {
    // private void AttachedToHand(Hand hand) {
    //     Debug.Log("BH2.AttachedToHand: entered");
    // }
    // private void OnAttachedToHand(Hand hand) {
    //     Debug.Log("BH2.OnAttachedToHand: entered");
    // }
    // // private void DetachedFromHand(Hand hand) {
    // private void DetachedFromHand() {
    //     Debug.Log("BH2.DetachedFromHand: entered");
    // }

    // private void OnDetachedFromHand(Hand hand) {
    //     Debug.Log("BH2.OnDetachedFromHand-parms: entered");
    // }
    // private void OnDetachedFromHand() {
    //     Debug.Log("BH2.OnDetachedFromHand-noparms: entered");
    // }
    private void DoIt() {
        Debug.Log("BH2.DoIt: entered");
        interactable.transform.position = initPos;
        interactable.transform.rotation = initRot;
    }
    private void DoIt2() {
        Debug.Log("BH2.DoIt2: entered");
    }
    private void ResetHandle() {
        Debug.Log("BH2.ResetHandle: entered");
        // transform.position = initPos;
        // transform.rotation = initRot;
        interactable.transform.position = initPos;
        interactable.transform.rotation = initRot;
    }

    private void OnHandHoverEnd(Hand hand)
    {
        Debug.Log($"BH2.OnHandHoverEnd: entered: lm.value={lm.value}");
        interactable.transform.position = initPos;
        interactable.transform.rotation = initRot;
        Debug.Log($"BH2.OnHandHoverEnd: circDrive.outAngle={circDrive.outAngle}");

        lm.value = 1.0f;
        circDrive.outAngle = -15.0f;
        // circDrive.outAngle = initRot;
        // circDrive.
    }
}