using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType
{
    NarrationStarter,
    Narration,
    Boss
}

public class IntereactableObject : MonoBehaviour
{
    public PlayerData data;
    [SerializeField] private InteractableType type;
    [SerializeField] private EmotionalState state;
    public bool isReusable = false;
    public bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case InteractableType.NarrationStarter:
                    StartNarration();
                    break;
                case InteractableType.Boss:
                    InteractBoss();
                    break;
                case InteractableType.Narration:
                    InteractItem();
                    break;
                default: break;
            }
            Debug.Log("interektavite yapuldu");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (type)
            {
                case InteractableType.NarrationStarter:
                    //
                    break;
                case InteractableType.Boss:
                    EventManager.Broadcast(GameEvent.onInteractionAreaExit);
                    isUsed = false;
                    break;
                case InteractableType.Narration:
                    //
                    break;
                default: break;
            }
        }
    }

    void StartNarration()
    {
        if (!isReusable)
        {
            if (!isUsed)
            {
                //     print("Started Narration.");
                //     EventManager.Broadcast(GameEvent.onSequenceStarted);
                //     isUsed = true;
                //     data.currentState = state;
                //

                transform.parent.GetComponent<NarrationSequence>().PlayNext();
            }
        }
    }
    void InteractBoss()
    {
        if (!isReusable)
        {

            if (!isUsed)
            {
                data.currentState = state;
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
                EventManager.Broadcast(GameEvent.onInteractable);
                print("Interacted with boss.");
                
                isUsed = true;

            }
        }
    }

    void InteractItem()
    {
        if (!isReusable)
        {
            if (!isUsed)
            {
                // EventManager.Broadcast(GameEvent.onNextSequence);
                // print("Item ile etkileştim.");
                // isUsed = true;
                // data.currentState = state;
                data.currentState = state;
                transform.parent.GetComponent<NarrationSequence>().PlayNext();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (transform.localScale.x >= transform.localScale.y)
        {
            Gizmos.DrawWireSphere(transform.position, GetComponent<CircleCollider2D>().radius * transform.localScale.x);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, GetComponent<CircleCollider2D>().radius * transform.localScale.y);
        }
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.onInteractionComplete, OnInteractionComplete);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.onInteractionComplete, OnInteractionComplete);
    }

    void OnInteractionComplete()
    {
        if (type == InteractableType.Boss)
        {
            switch (data.currentState)
            {
                case EmotionalState.Depression:
                    print("Load Deppression Battle");
                    LevelLoader.instance.LoadNextLevel("Depression");
                    isUsed = true;
                    break;
                case EmotionalState.Disappointment:
                    LevelLoader.instance.LoadNextLevel("Disappointment");
                    print("Load Disappointment Battle");
                    isUsed = true;
                    break;
                case EmotionalState.Resentment:
                    LevelLoader.instance.LoadNextLevel("Resentment");
                    print("Load Resentment Battle");
                    isUsed = true;
                    break;

                default: print("There is a problem."); break;
            }
        }
    }


}
