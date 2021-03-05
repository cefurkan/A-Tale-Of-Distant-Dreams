using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder instance;
    public PlayerData data;

     private void Awake()
    {
        //singleton deseni
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //scene load olayında bu scriptin bulunduğu gameobject'i yoketmemeli.
        DontDestroyOnLoad(gameObject);


    }
}
