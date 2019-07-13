using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    public Camera m_camera;
    public SteamVR_Input_Sources targetSource;
    public SteamVR_Action_Boolean clickAction;

    private GameObject currentObject = null;
    private PointerEventData data = null;

    [Tooltip("The model you want to send events (like clicks) to")]
    public GameObject eventHandler;
    private GameObject gm;

    protected override void Awake() {
        base.Awake();

        data = new PointerEventData(eventSystem);
        
        // gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        gm = GameObject.Find("GameMaster");
    }


    public override void Process() {
        // Debug.Log("VRInputModule.Process: entered");
        // reset data, set camera
        data.Reset();
        data.position = new Vector2(m_camera.pixelWidth / 2, m_camera.pixelHeight / 2);

        // raycast
        eventSystem.RaycastAll(data, m_RaycastResultCache);
        data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        currentObject = data.pointerCurrentRaycast.gameObject;

        // clear
        m_RaycastResultCache.Clear();

        // hover
        HandlePointerExitAndEnter(data, currentObject);

        // press
        if (clickAction.GetStateDown(targetSource)) {
            ProcessPress(data);
        }

        if (clickAction.GetStateUp(targetSource)) {
            ProcessRelease(data);
        }

    }

    public PointerEventData GetData() {
        return data;
    }

    private void ProcessPress(PointerEventData data) {
        Debug.Log("VRInputModule.ProcessPress: entered");

        // set raycast
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        // check for object hit, get the down handler
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(currentObject, data, ExecuteEvents.pointerDownHandler);

        // if no down handler, try and get click handler
        if (newPointerPress == null)
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

        // set data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = currentObject;

        string btnPressed = null;
        if (data.pointerPress)
        {
            if (data.pointerPress.tag == "lazy_susan_left_btn")
            {
                Debug.Log("VRInputModule: lazy susan left pressed");
                btnPressed = "left";
            }
            else if (data.pointerPress.tag == "lazy_susan_right_btn")
            {
                Debug.Log("VRInputModule: lazy susan right pressed");
                btnPressed = "right";
            }
        }

        // send a "click" event to the user model
        if (btnPressed != null)
        {
            eventHandler.SendMessage("LazySusanBtnClicked", btnPressed);
            gm.SendMessage("LazySusanBtnClicked", btnPressed);
        }

    }

    private void ProcessRelease(PointerEventData data) {
        // Debug.Log("VRInputModule.ProcessRelease: entered");
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

        if (data.pointerPress == pointerUpHandler) {
            // ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        // clear selected game object
        eventSystem.SetSelectedGameObject(null);

        // reset data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}
