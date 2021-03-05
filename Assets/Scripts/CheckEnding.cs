using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnding : MonoBehaviour
{
    public GameObject Blockage;
    public PlayerData data;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(data.personalities.Count == 3){
                Blockage.SetActive(false);
            }
        }
    }
}
