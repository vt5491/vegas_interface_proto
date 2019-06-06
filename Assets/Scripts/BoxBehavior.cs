using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    GameObject leftHand;
    // Start is called before the first frame update
    void Start()
    {
        leftHand = GameObject.Find("LeftHand");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BoxBehavior: entered onTrigger");
        leftHand.SendMessage("BoxEvent");
    }
}
