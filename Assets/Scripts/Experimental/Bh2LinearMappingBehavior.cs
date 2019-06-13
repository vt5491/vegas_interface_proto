using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Valve.VR.InteractionSystem;

public class Bh2LinearMappingBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private LinearMapping lm;
    private bool pullEventFired;
    private UnityEvent pullEvent;
    private LazySusan ls;
    AudioSource slotMachineAudio;
    private GameObject anim_go;
    private Animation animation;
    private Animator animator;
    private int lsState = 1;

    void Awake() {
       lm = this.GetComponent<LinearMapping>();
       ls = GameObject.Find("LazySusan").GetComponent<LazySusan>();
       pullEvent = new UnityEvent();
       pullEvent.AddListener(callLazySusan);
       pullEventFired = false;
    }
    void Start()
    {
        slotMachineAudio = GetComponent<AudioSource>();

        anim_go = GameObject.Find("lazySusan_basic_dae");
        animation = anim_go.GetComponent<Animation>();
        // anim["spin"].layer = 123;
        animator = anim_go.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"Bh2LinearMappingBehavior.Update: lm.value={lm.value}");
        if (lm.value < 0.1 && !pullEventFired) {
            // Debug.Log($"Bh2LinearMappingBehavior.Update: lm.value={lm.value}");
            pullEvent.Invoke();
            pullEventFired = true;
            // and play a sound
            slotMachineAudio.Play(0);
            // and invoke animation
            // anim.Play("spin");
            // animator.Play("Take");
            // animation.Play("Take 001");
            // animation.Play("Take");
            // animation.Play();
            Debug.Log($"Bh2LinearMappingBehavior.Update: kicking off animator");
            // animator.Play("Run");
            animator.Play("Base Layer.Run_00" + lsState);
            lsState = lsState + 1;
            if (lsState > 4) {
                lsState = 1;
            }
        }
        else if(lm.value > 0.1 && pullEventFired) {
            // otherwise we've crossed back up and we need to reset the
            // canons to fire another event.
            pullEventFired = false;
        }
        
    }

    void callLazySusan() {
        Debug.Log($"Bh2LinearMappingBehavior.Update: now calling LazySusan");
        ls.RotateDelta(10.0f);
    }
}
