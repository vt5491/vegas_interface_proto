using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private LazySusan2 ls;
    // Start is called before the first frame update
    void Start()
    {
    //    ls = GameObject.Find("LazySusan").GetComponent<LazySusan2>();
    //    ls = GameObject.Find("LazySusan/lv_aggregate").GetComponent<LazySusan2>();
       ls = GameObject.Find("lv_aggregate").GetComponent<LazySusan2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LazySusanBtnClicked(string btnPressed) {
        Debug.Log($"GameMaster.LazySusanBtnClicked: btnPressed={btnPressed}");
        // ls.SendMessage("Rotate");
        // ls.RotateDelta(10.0f);
        // ls.rotateLeft();
        ls.SetRotDir(btnPressed);
        if (btnPressed == "left") {
            // ls.anim.SetBool("left_btn_pressed", true);
            ls.left_btn_pressed = true;
        }
        else if (btnPressed == "right") {
            // ls.anim.SetBool("right_btn_pressed", true);
            ls.right_btn_pressed = true;
        }
    }
    
    private void LazySusanRotate() {
        Debug.Log("GameMaster.LazySusanRotate: calling ls.rotate");
        ls.rotate();
    } 

    private void LazySusanAnimDone() {
        ls.animDone();
    }
}
