using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// based on "vr with andrew" : https://www.youtube.com/watch?v=vNqHRD4sqPc&t=52s
public class Pointer : MonoBehaviour
{
    public float defaultLength = 5.0f;
    public GameObject dot;

    public VRInputModule inputModule;
    
    private LineRenderer lineRenderer;


    private void  Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateLine();
        
    }

    private void UpdateLine() {
        PointerEventData data = inputModule.GetData();
        // float targetLength = defaultLength;
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;

        RaycastHit hit = CreateRaycast(targetLength);

        Vector3 endPos = transform.position + (transform.forward * targetLength);

        if (hit.collider != null) {
            endPos = hit.point;
        }

        dot.transform.position = endPos;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPos);

    }

    private RaycastHit CreateRaycast(float length) {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
