using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;
public class HandleBehavior : MonoBehaviour
{
    // private GameObject linearMapping;
    private LinearMapping linearMapping;
    private LazySusan ls;
    private float lastLinearVal = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HandleBehavior.Start: entered");
        // if (linearMapping == null)
        // {
        //     linearMapping = GetComponent<LinearMapping>();
        // }
        linearMapping = GameObject.Find("LinearMapping").GetComponent<LinearMapping>();
        ls = GameObject.Find("LazySusan").GetComponent<LazySusan>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(linearMapping.value != 0) {
            // Debug.Log($"HandleBehavior.Update: linearMapping.value={linearMapping.value}");
            var linearVal = linearMapping.value;

            var deltaVal = linearVal - lastLinearVal;
            // Debug.Log($"HandleBehavior.Update: deltaVal={deltaVal}, lastLinearVal={lastLinearVal}");
            if (Mathf.Abs(deltaVal) > 0.01f ) {
                ls.RotateDelta(deltaVal * 360);
                lastLinearVal = linearVal;
            }
    }
            // Debug.Log($"HandleBehavior.Update: linearVal={linearVal}, lastLinearVal={lastLinearVal}");
        // }
        
}
