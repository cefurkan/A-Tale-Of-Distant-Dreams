using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Vector2 Variable", menuName = "Variables/Vector2", order = 1)]
public class S_Vector2 : ScriptableObject
{
    //Her yerden erişilebilen değişkenler için işe yarıyo bu yöntem, iyidir aslında.
    public Vector2 Value;
}
