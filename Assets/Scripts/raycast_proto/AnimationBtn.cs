using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
// using UnityEngine.UI;
public class AnimationBtn : MonoBehaviour
{
    private GameObject anim_go;
    // private Animation animation;
    private Animator animator;
    void Start()
    {
        anim_go = GameObject.Find("bigvegas");
        animator = anim_go.GetComponent<Animator>();
    }

    // public void OnButtonDown(Hand fromHand)
    // {
    //     Debug.Log("SambaButton.OnButtonDown: button pressed");
    //     animator.Play("stand_to_freehang");
    // }
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("AnimationBtn.OnPointerClick event");

        // m_CandlestickPlayable.Play();
        animator.Play("Base Layer.stand_to_freehang");
    }
}
