using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
public class Handle : MonoBehaviour
{  
    private Interactable interactable;
    private Vector3 initPos;
    private Quaternion initRot;
    private LinearMapping lm;
    private CircularDrive circDrive;
    // Start is called before the first frame update
    void Start()
    {
        interactable = this.GetComponent<Interactable>();
        initPos = transform.position;
        initRot = transform.rotation;

        lm = GameObject.Find("HandleLinearMapping").GetComponent<LinearMapping>();

        circDrive = GetComponent<CircularDrive>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"Handle.Update: lm.value={lm.value}");
    }

    private void OnHandHoverEnd(Hand hand)
    {
        // Debug.Log("Handle.OnHandleHoverEnd: entered");
        interactable.transform.position = initPos;
        interactable.transform.rotation = initRot;

        lm.value = 1.0f;
        circDrive.outAngle = -15.0f;
    }
}
