using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public S_Float ButtonTime;
    Canvas canvas;
    RectTransform InteractPanel;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        InteractPanel = canvas.transform.Find("InteractPanel").GetComponent<RectTransform>();

        InteractPanel.gameObject.SetActive(false);
        ButtonTime.Value = 0;
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.onInteractionComplete, OnHoldComplete);
        EventManager.AddHandler(GameEvent.onInteractable, OnInteractable);
        EventManager.AddHandler(GameEvent.onInteractionAreaExit, OnAreaExit);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.onInteractionComplete, OnHoldComplete);
        EventManager.RemoveHandler(GameEvent.onInteractable, OnInteractable);
        EventManager.RemoveHandler(GameEvent.onInteractionAreaExit, OnAreaExit);
    }

    void OnInteractable()
    {
        InteractPanel.gameObject.SetActive(true);
    }
    void OnHoldComplete()
    {
        InteractPanel.gameObject.SetActive(false);
        ButtonTime.Value = 0;
    }
    void OnAreaExit()
    {
        InteractPanel.gameObject.SetActive(false);
    }
}
