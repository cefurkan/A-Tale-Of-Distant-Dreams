using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionButton : MonoBehaviour
{
    public float holdFactor = 1f;
    public S_Float ButtonValue;
    Image RadialBar;
    // Start is called before the first frame update

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.onInteractionAreaExit, OnExit);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.onInteractionAreaExit, OnExit);
    }


    void OnExit()
    {
        ButtonValue.Value = 0f;
    }


    void Start()
    {
        RadialBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (ButtonValue.Value <= 1.0f)
            {
                ButtonValue.Value += holdFactor * Time.deltaTime;
                RadialBar.fillAmount = ButtonValue.Value;
            }
            else
            {
                EventManager.Broadcast(GameEvent.onInteractionComplete);
            }
        }
        else
        {
            if (RadialBar.fillAmount > 0f)
            {
                ButtonValue.Value -= holdFactor / 2 * Time.deltaTime;
                RadialBar.fillAmount = ButtonValue.Value;
            }
        }


    }
}
