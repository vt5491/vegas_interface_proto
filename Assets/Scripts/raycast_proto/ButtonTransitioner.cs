﻿using System.Collections;
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
    private PlayableDirector m_ElvisLever2Playable;

    private GameObject m_BigVegas;
    // private Animation animation;
    private Animator m_BigVegasAnimator;
    private GameObject m_BigVegas_2;
    private void Awake() {
        m_Image = GetComponent<Image>();
    }

    void Start() {
        m_CandlestickPull = GameObject.Find("candlestick_pull_fbx");
        m_CandlestickPlayable = m_CandlestickPull.GetComponent<PlayableDirector>();

        // m_BigVegas = GameObject.Find("bigvegas_2");
        m_BigVegas_2 = GameObject.Find("bigvegas_2");
        m_ElvisLever2Playable = m_BigVegas_2.GetComponent<PlayableDirector>();

        m_BigVegas = GameObject.Find("elvis_lever_2");
        m_BigVegasAnimator = m_BigVegas.GetComponent<Animator>();
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
        // m_BigVegasAnimator.Play("Base Layer.stand_to_freehang");
        // m_BigVegasAnimator.Play("stand_freehang_full_cycle");
        // m_BigVegasAnimator.Play("sidebar_pull");
        m_ElvisLever2Playable.Play();
    }
}
