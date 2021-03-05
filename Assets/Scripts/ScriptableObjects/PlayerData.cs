using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public EmotionalState currentState;
    public List<Personality> personalities;
    public Vector3 lastPosition;

}
