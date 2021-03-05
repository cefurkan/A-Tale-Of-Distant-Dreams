using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed;
    public GameObject stick;
    public GameObject ball;
    float random = -1.6f;
    bool ballWave = false;

    private IEnumerator startWave;
    void Start()
    {
        InvokeRepeating("GetRandomFloat", .05f, 1f);
        startWave = StartWave();
        StartCoroutine(startWave);
    }
    private void Update()
    {
    
        transform.position = new Vector2(transform.position.x, random);

        if (Boss.instance.Health <= Boss.instance.MaxHealth / 2)
        {
            StopCoroutine(startWave);
           
            if(!ballWave)
            {
                BallWave();
            }
        }
    }
    IEnumerator StartWave()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnObstacles(stick);
            yield return new WaitForSeconds(1f);
        }

    }


    private void SpawnObstacles(GameObject obstacle)
    {
        Instantiate(obstacle, transform.position, transform.rotation);
    }
    float GetRandomFloat()
    {
        return random = Random.Range(-1.4f, -3.5f);
    }
   void BallWave()
    {
        Instantiate(ball, new Vector2(3f, -1f), Quaternion.identity);
        Instantiate(ball, new Vector2(0f, -1f), Quaternion.identity);
        Instantiate(ball, new Vector2(-3f, -1f), Quaternion.identity);
        ballWave = true;
    }



}


