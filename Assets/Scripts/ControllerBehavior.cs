using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerBehavior : MonoBehaviour
{
    private const float GRIP_DECELERATION_INT = 1.0f;
    public float movementSpeed = 5.0f;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Vector2 rotateAction;

    [Tooltip("Smaller equals smaller movement amount. 0.1 good for cm level")]
    public float sensitivityFactor = 1.0f;
    private float ONE_DEG = Mathf.PI / 180.0f;
    // private float rot;
    // private Quaternion startRot;
    private Vector3 lastRot = new Vector3(0, 0, 0);
    // private Vector3 baselineRot = new Vector3(0, 0, 0);
    private float rotDelta = 60.0f;
    private int rotDir = 1;
    private Vector3 startEuler;
    // public GameObject player = GameObject.Find("Player");
    public GameObject player;
	private Vector3 gripStartPos;
    // private Vector3 lastCtrlPos;
    private Vector3 startCtrlPos;
	private Vector3 playerStartPos;
    private bool isGripping = false;
    private bool isRotating = false;
    private float gripTransformDivFactor;
    public float gripTransformScaleFactor;
	private float gripTransformAddFactor;
    // rember the last grip movement dir and time to implement controller movement fadedown (intertia)
    private Vector3 lastGripVel;
    private Vector3 lastPlayerPos;
    private float lastGripTime;
    void Awake() {
    //    player = GameObject.Find("Player"); 
    }
    void Start()
    {
        // this.rot =  ONE_DEG * 90.0f; 
        // player = GameObject.Find("Player");
        // player = GameObject.Find("[CameraRig]");
        player = player ? player : GameObject.Find("Player");
        // gripTransformScaleFactor = 1.7f;
        gripTransformDivFactor = 5.0f;
        gripTransformAddFactor = 1.0f;

        lastGripTime = Time.time;
        lastPlayerPos = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (
            // SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.LeftHand)
            // ||false
            SteamVR_Input._default.inActions.Pullate.GetStateDown(SteamVR_Input_Sources.LeftHand)
            )
        {
            // print("InputController.Update: GrabGrip down event occurred");
            // Debug.Log("InputController.Update: GrabGrip down event occurred");
            gripStartPos = transform.position;
            startCtrlPos = gripStartPos;
            playerStartPos = player.transform.position;
            isGripping = true;
        }
        else if (
            // SteamVR_Input._default.inActions.GrabGrip.GetStateUp(SteamVR_Input_Sources.LeftHand)
            // false
            SteamVR_Input._default.inActions.Pullate.GetStateUp(SteamVR_Input_Sources.LeftHand )
        )
        {
            // print("InputController.Update: GrabGrip up event occurred");
            isGripping = false;
            lastGripTime = Time.time;
            // print($"lastGripVel={lastGripVel}, mag={lastGripVel.magnitude}");
        }


        if (isGripping)
        {
            //vt-x
            player.transform.position = playerStartPos;
            //end vt-x
            // Vector3 ctrlDeltaPos = transform.position - gripStartPos;
            Vector3 ctrlDeltaPos = transform.position - startCtrlPos;
            // Vector3 ctrlDeltaPos = transform.position;
            // lastCtrlPos = lastCtrlPos + ctrlDeltaPos; 
            // lastCtrlPos = transform.position; 
            // var scaledDelta = ctrlDeltaPos * 2.7f;
            // ctrlDeltaPos *= 35.0f;
            ctrlDeltaPos *= 35.0f * sensitivityFactor;

            // var lastPlayerPos = player.transform.position;
            // lastPlayerPos = player.transform.position;

            Vector3 newPos = playerStartPos - ctrlDeltaPos;

            // playerStartPos = player.transform.position;
            // playerStartPos = newPos;
            player.transform.position = newPos;

            lastGripVel = newPos - lastPlayerPos;
            //note the placement of this is important.  Want to do it after the position has been set
            //so the grip intertia routine doesn't have too much of a "rubber band" effect.
            lastPlayerPos = player.transform.position;
        }
        else if (!isGripping && Time.time - lastGripTime < 1.0f)
        {
            var deltaTime = Time.time - lastGripTime;

            // player.transform.position += lastGripVel * (1.0f - (deltaTime / GRIP_DECELERATION_INT)) * 0.08f; 
            // note: 2.8 = 0.08 * 35 
            player.transform.position += lastGripVel * (1.0f - (deltaTime / GRIP_DECELERATION_INT)) * 2.8f; 
            // player.transform.position += lastGripVel * (1.0f - (deltaTime / GRIP_DECELERATION_INT)) * sensitivityFactor; 
             
            // var vel = player.transform.position - lastPlayerPos;
            // player.transform.position += vel * (1.0f - (deltaTime / GRIP_DECELERATION_INT)) * 0.08f; 
        }

        // if (SteamVR_Input._default.inActions.JoyStickRotate.)
        Vector2 joystickVal = rotateAction.GetAxis(SteamVR_Input_Sources.LeftHand);
        // print($"joystickval.x={joystickVal.x},joystickVal.y={joystickVal.y}");
        if (joystickVal.x > 0.5) {
            // startRot = transform.rotation;
            // startEuler = transform.localEulerAngles;
            // startRot = player.transform.rotation;
            isRotating = true;
            rotDir = 1;

        }
        else if (joystickVal.x < -0.5) {
            isRotating = true;
            rotDir = -1;
        }
        else {
            isRotating = false;
        }


        // if (SteamVR_Input._default.inActions.ButtonRotate.GetStateUp(SteamVR_Input_Sources.LeftHand)) {
        if (SteamVR_Input._default.inActions.ButtonRotate.GetStateUp(SteamVR_Input_Sources.Any)) {
            // print("ButtonRotate up event detected");
            isRotating = false;
            // rotDir = 1;
        };
        // if(SteamVR_Input._default.inActions.ButtonRotate.GetStateDown(SteamVR_Input_Sources.LeftHand)) {
        if(SteamVR_Input._default.inActions.ButtonRotate.GetStateDown(SteamVR_Input_Sources.Any)) {
            // SteamVR_Input._default.inActions.ButtonRotate.pose

            // print("ButtonRotate down event detected");
            // Debug.Log("ButtonRotate down event detected");
            isRotating = true;
            rotDir = 1;
        }
        // if(SteamVR_Input._default.inActions.TrackPadTouch.GetStateDown(SteamVR_Input_Sources.Any)) {
        //     Debug.Log("TrackPadTouch down event detected");
        // }
        var axis = SteamVR_Input._default.inActions.JoyStickRotate.GetAxis(SteamVR_Input_Sources.Any);
        // Debug.Log($"touchpad axis= {axis.ToString()}, x={axis.x}");
        if(axis.x > 0.5) {
            isRotating = true;
            rotDir = 1;
        }
        else if(axis.x < -0.5) {
            isRotating = true;
            rotDir = -1;
        }
        else {
            isRotating = false;
        }

        if (isRotating)
        {
            // var deltaRot = transform.localEulerAngles.y - lastRot.y;
            // lastRot = transform.localEulerAngles;
            // player.transform.rotation = Quaternion.Euler(0, baselineRot.y + transform.localEulerAngles.y - startEuler.y, 0);
            // player.transform.rotation.y += rotDelta * Time.deltaTime;
            lastRot = player.transform.localEulerAngles;
            player.transform.rotation = Quaternion.Euler(0, lastRot.y + rotDelta * rotDir * Time.deltaTime, 0 );
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ControlerBehavior: entered onTrigger");
    }

    private void BoxEvent() {
        Debug.Log("ControllerBehavior.BoxEvent: box event detected");
    }

    private void BtnEvent() {
        Debug.Log("ControllerBehavior.BtnEvent: btn event detected");
    }
}
