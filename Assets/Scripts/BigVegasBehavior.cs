using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigVegasBehavior : MonoBehaviour
{
    private Animator anim;
    // We need to remember initial y rot, because animations
    // can sometime affect it.
    // private float initYRot;
    public float InitYRot { get; set; }
    void Start()
    {
        anim = GetComponent<Animator>();
        // InitYRot = transform.rotation.y;
        InitYRot = transform.eulerAngles.y;
    }

    void Update()
    {
        
    }
    private void LazySusanBtnClicked(string btnPressed) {
        // Debug.Log($"BigVegasBehavior: BtnClicked detected");
        resetYRot();
        anim.SetBool("isIdling", false);
        anim.SetBool("isPulling", true);

        Debug.Log($"BtnClicked: btnPressed={btnPressed}");
    }

    public void resetYRot() {
        Debug.Log($"BigVegasBehavior.resetYRot: resetting y rot to {InitYRot}");
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, InitYRot, transform.eulerAngles.z);
    }
    public void doIt() {
        Debug.Log("BigVegasBehavior.doIt: hello");
    }

    // getters and setters
    // public float InitYRot
    // {
    //     get { return initYRot; }
    //     set { initYRot = value; }
    // }
}
