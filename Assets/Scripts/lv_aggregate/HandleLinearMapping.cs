using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Valve.VR.InteractionSystem;
public class HandleLinearMapping : MonoBehaviour
{
    private LinearMapping lm;
    private bool pullEventFired;
    private UnityEvent pullEvent;
    private LazySusan ls;
    AudioSource slotMachineAudio;
    private GameObject anim_go;
    // private Animation animation;
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

        // anim_go = GameObject.Find("lazySusan_basic_dae");
        // anim_go = GameObject.Find("lv_aggregate_overview");
        anim_go = GameObject.Find("lv_aggregate");
        // animation = anim_go.GetComponent<Animation>();
        // anim["spin"].layer = 123;
        animator = anim_go.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lm.value < 0.1 && !pullEventFired) {
            pullEvent.Invoke();
            pullEventFired = true;
            // and play a sound
            slotMachineAudio.Play(0);
            // and invoke animation
            animator.Play("Base Layer.run_00" + lsState);
            lsState = lsState + 1;
            if (lsState > 4) {
                lsState = 1;
            }
            // animator.Play("Base Layer.run_000");
        }
        else if(lm.value > 0.1 && pullEventFired) {
            // otherwise we've crossed back up and we need to reset the
            // canons to fire another event.
            pullEventFired = false;
        }
        
    }

    void callLazySusan() {
        Debug.Log($"HandleLinearMapping.callLazySusan: now calling LazySusan");
        // ls.RotateDelta(10.0f);
    }
}
