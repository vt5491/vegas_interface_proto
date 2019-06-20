using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
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
        Debug.Log("ButtonBehavior: entered onTrigger");
        leftHand.SendMessage("BtnEvent");
    }

    public void onClick() {
        Debug.Log("ButtonBehavior: entered onClick");
    }

    public void doIt() {
        Debug.Log("ButtonBehavior.doIt: entered");
    }
}
