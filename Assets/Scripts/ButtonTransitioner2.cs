using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ButtonTransitioner2 : MonoBehaviour
{
    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.grey;
    public Color32 m_DownColor = Color.white;
    // Start is called before the first frame update
    private Image m_Image = null;
    private void Awake() {
        m_Image = GetComponent<Image>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("ButtonTransitioner2.OnPointerEnter event");
        m_Image.color = m_HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("ButtonTransitioner2.OnPointerExit event");
        m_Image.color = m_NormalColor;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("ButtonTransitioner2.OnPointerDown event");
        m_Image.color = m_DownColor;
    }
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("ButtonTransitioner2.OnPointerClick event");
        m_Image.color = m_HoverColor;

        // m_CandlestickPlayable.Play();
        // m_BigVegasAnimator.Play("Base Layer.stand_to_freehang");
        // m_BigVegasAnimator.Play("stand_freehang_full_cycle");
        // m_BigVegasAnimator.Play("sidebar_pull");
        // m_ElvisLever2Playable.Play();
    }
}
