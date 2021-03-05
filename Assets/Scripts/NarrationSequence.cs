using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class NarrationSequence : MonoBehaviour
{
    //burada bir sequence tanımı yapılacak.
    //öncelikle sequence starter ile etkileşime geçilecek.
    //bir GameObject Array olacak. Sırası ile aktif edilip alpha değerleri ayarlanacak.
    //belki başka aksiyonlar da yapılabilir.


    public GameObject starter;
    public List<GameObject> sequence;
    public GameObject Boss;
    int index = 0;
    public EmotionalState state;
    public PlayerData data;
    //public bool isCompleted = false;



    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.onSequenceStarted, OnSeqStart);
        EventManager.AddHandler(GameEvent.onNextSequence, OnNextSeq);
        EventManager.AddHandler(GameEvent.onSequenceEnded, OnSeqEnded);
    }


    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.onSequenceStarted, OnSeqStart);
        EventManager.RemoveHandler(GameEvent.onNextSequence, OnNextSeq);
        EventManager.RemoveHandler(GameEvent.onSequenceEnded, OnSeqEnded);
    }


    void OnSeqStart()
    {
        if (data.currentState == state /*|| data.personalities.Length == 0 */)
        {
            sequence[index].SetActive(true);
            sequence[index].GetComponent<SpriteRenderer>().DOFade(1, 4);
            print(sequence[index].name + " aktif edildi.");
            data.currentState = state;
        }

        //sequence[index].SetActive(true);
    }

    void OnNextSeq()
    {
        if (data.currentState == state)
        {
            sequence[index].GetComponent<IntereactableObject>().isUsed = true;
            index++;
            if (index < sequence.Count)
            {
                sequence[index].SetActive(true);
                sequence[index].GetComponent<SpriteRenderer>().DOFade(1, 1);
            }
            else
            {
                EventManager.Broadcast(GameEvent.onSequenceEnded);
            }
        }
    }

    void OnSeqEnded()
    {
        Boss.SetActive(true);
    }

    //dikkat abi, oyunda boss fight sonrası bu scene'e döndüğümüz zaman da her sequence'ı sıfırlamasın.
    private void Start()
    {
        if (EmotionalState.Resentment == state &&
             (data.personalities.Contains(Personality.Forgiveness) || data.personalities.Contains(Personality.Anger)))
        {
            return;
        }
        else if (EmotionalState.Disappointment == state &&
        (data.personalities.Contains(Personality.Acceptance) || data.personalities.Contains(Personality.Denial)))
        {
            return;
        }
        else if (EmotionalState.Depression == state &&
        (data.personalities.Contains(Personality.Freedom) || data.personalities.Contains(Personality.Obsession)))
        {
            return;
        }
        for (int i = 0; i < sequence.Count; i++)
        {
            sequence[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            sequence[i].SetActive(false);
        }

        Boss.SetActive(false);
    }

    public void PlayNext()
    {
        if (index == 0)
        {
            sequence[index].SetActive(true);
            sequence[index].GetComponent<SpriteRenderer>().DOFade(1, 4);
            print(sequence[index].name + " aktif edildi.");
            index++;
        }
        else if (index < sequence.Count)
        {
            sequence[index - 1].GetComponent<IntereactableObject>().isUsed = true;
            // index++;
            if (index < sequence.Count)
            {
                sequence[index].SetActive(true);
                sequence[index].GetComponent<SpriteRenderer>().DOFade(1, 1);
                index++;
            }
            else
            {
                EventManager.Broadcast(GameEvent.onSequenceEnded);
            }
        }
        else
        {
            Boss.SetActive(true);
        }

    }

}
