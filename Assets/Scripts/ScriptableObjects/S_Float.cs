using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float Variable", menuName = "Variables/Float", order = 1)]
public class S_Float : ScriptableObject
{
    public float Value;
    void ResetValue()
    {
        Value = 0;
    }
}
