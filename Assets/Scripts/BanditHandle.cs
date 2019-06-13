
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
public class BanditHandle : MonoBehaviour
{
    // private GameObject linearMapping;
    private LinearMapping linearMapping;
    private LazySusan ls;
    private float lastLinearVal = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BanditHandle.Start: entered");
        // if (linearMapping == null)
        // {
        //     linearMapping = GetComponent<LinearMapping>();
        // }
        linearMapping = GameObject.Find("BanditHandleValue").GetComponent<LinearMapping>();
        ls = GameObject.Find("LazySusan").GetComponent<LazySusan>();

        // draw a cube at BanditHandleStart and BanditHandleEnd
        // GameObject start = GameObject.Find("/BanditHandleParent/BanditHandleStart");
        // GameObject start = GameObject.Find("./BanditHandleStart");
        GameObject start = GameObject.Find("BanditHandleStart");
        GameObject startCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        startCube.transform.position = start.transform.position;
        startCube.transform.rotation = start.transform.rotation;
        startCube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

        GameObject end = GameObject.Find("BanditHandleEnd");
        GameObject endCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        endCube.transform.position = end.transform.position;
        endCube.transform.rotation = end.transform.rotation;
        endCube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

    }

    // Update is called once per frame
    void Update()
    {
        // if(linearMapping.value != 0) {
            // Debug.Log($"HandleBehavior.Update: linearMapping.value={linearMapping.value}");
            var linearVal = linearMapping.value;

            var deltaVal = linearVal - lastLinearVal;
            // Debug.Log($"HandleBehavior.Update: linearVal={linearVal}, deltaVal={deltaVal}, lastLinearVal={lastLinearVal}");
            if (Mathf.Abs(deltaVal) > 0.01f ) {
                ls.RotateDelta(deltaVal * 360);
                lastLinearVal = linearVal;
            }
    }
            // Debug.Log($"HandleBehavior.Update: linearVal={linearVal}, lastLinearVal={lastLinearVal}");
        // }

    void HandAttached() {
        Debug.Log($"BanditHandle.HandAttached: entered");
    }
        
}
