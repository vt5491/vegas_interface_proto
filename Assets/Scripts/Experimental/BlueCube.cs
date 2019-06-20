using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class BlueCube : MonoBehaviour
{
    private Interactable interactable;
    private Vector3 oldPosition;
    private Quaternion oldRotation;

    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);
    void Awake()
    {
        interactable = this.GetComponent<Interactable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BlueCube.Start: entered");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandHoverUpdate(Hand hand)
    {
        Debug.Log("BlueCube.HandHoverUpdate: entered");
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            // Save our position/rotation so that we can restore it when we detach
            oldPosition = transform.position;
            oldRotation = transform.rotation;

            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
            hand.HoverLock(interactable);

            // Attach this object to the hand
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
        else if (isGrabEnding)
        {
            // Detach this object from the hand
            hand.DetachObject(gameObject);

            // Call this to undo HoverLock
            hand.HoverUnlock(interactable);

            // Restore position/rotation
            transform.position = oldPosition;
            transform.rotation = oldRotation;
        }
    }
}
