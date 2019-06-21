using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.grey;
    public Color32 m_DownColor = Color.white;
    
    private Image m_Image = null;
    private GameObject m_CandlestickPull;
    private PlayableDirector m_CandlestickPlayable;

    private void Awake() {
        m_Image = GetComponent<Image>();
    }

    void Start() {
        m_CandlestickPull = GameObject.Find("candlestick_pull_fbx");
        m_CandlestickPlayable = m_CandlestickPull.GetComponent<PlayableDirector>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("ButtonTransitioner.OnPointerEnter event");
        m_Image.color = m_HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("ButtonTransitioner.OnPointerExit event");
        m_Image.color = m_NormalColor;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("ButtonTransitioner.OnPointerDown event");
        m_Image.color = m_DownColor;
    }
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("ButtonTransitioner.OnPointerClick event");
        m_Image.color = m_HoverColor;

        m_CandlestickPlayable.Play();
    }
}
