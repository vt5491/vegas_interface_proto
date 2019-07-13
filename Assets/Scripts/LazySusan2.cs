using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazySusan2 : MonoBehaviour
{
    [Header("User Settings")]
    public int size;

    private string rotDir = "left";

    // private Animator anim;
    public Animator anim { get; private set;}
    public bool left_btn_pressed {get; set;}
    public bool right_btn_pressed {get; set;}
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void rotate() {
        // (rotDir == "left") ? rotateLeft() : rotateRight();
        // Debug.Log($"LazySusan2.rotate: rotDir={rotDir}");
        // if (rotDir == "left") 
        //     rotateLeft();
        // else
        //     rotateRight();
        if (left_btn_pressed) {
            Debug.Log($"LS2.rotate: setting anim left_btn_pressed");
            anim.SetBool("left_btn_pressed", true);

            rotateLeft();
        }
        else if (right_btn_pressed) {
            Debug.Log($"LS2.rotate: setting anim right_btn_pressed");
            anim.SetBool("right_btn_pressed", true);

            rotateRight();
        }

        // and reset the key pressed for the next animation
        // left_btn_pressed = false;
        // right_btn_pressed = false;

    }
    private void rotateLeft() {
        int currentState = anim.GetInteger("ls_state");
        int nextState = (currentState + 1) % size;

        Debug.Log($"LazySusan2.rotateLeft: currentState={currentState}, nextState={nextState}");
        anim.SetInteger("ls_state", nextState);

        // float currentOffset = anim.GetFloat("ls_offset");
        // float nextOffset = (currentOffset + 0.25f) % 1.0f;
        // float nextOffset = (currentOffset + 0.125f) % 1.0f;
        // float nextOffset = nextState * 0.25f;
        // anim.SetFloat("ls_offset", nextOffset);
    }

    private void rotateRight() {
        int currentState = anim.GetInteger("ls_state");
        int nextState = (currentState - 1);
        if (nextState < 0) {
            // nextState = size;
            nextState = size - 1;
        }
        Debug.Log($"LazySusan2.rotateRight: currentState={currentState}, nextState={nextState}");

        anim.SetInteger("ls_state", nextState);

        // float nextOffset = nextState * 0.25f;
        // anim.SetFloat("ls_offset", nextOffset);
    }

    public void SetRotDir(string dir) {
        if (dir == "left") {
            rotDir = "left";
        }
        else if (dir == "right") {
            rotDir = "right";
        }
    } 

    public void animDone() {
        Debug.Log($"LazySusan2.animDone: entered");
        anim.SetInteger("ls_anim_dir", 0);
        // anim.SetBool("left_btn_pressed", false);
        // anim.SetBool("right_btn_pressed", false);
        left_btn_pressed = false;
        right_btn_pressed = false;
        anim.SetBool("left_btn_pressed", false);
        anim.SetBool("right_btn_pressed", false);
    }
}
