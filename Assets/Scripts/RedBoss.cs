using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : MonoBehaviour
{
    public Transform exitPos;


    public static RedBoss instance;
    void Start()
    {
        instance = this;   
    }

 
}
