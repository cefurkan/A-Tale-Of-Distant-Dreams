using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayAreaMov : MonoBehaviour
{
    
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;
    public string activeScene;
    public bool isMoveActive = false;

    //Vector3 minScale;
    //public Vector3 maxScale;
    //public bool repeatable;
    //public float speedScale = 2f;
    //public float duration = 5f;


    void Start()
    {
        waitTime = startWaitTime;

        activeScene = LevelLoader.instance.GetActiveScreenName();

        if (activeScene == "Depression" || activeScene == "Resentment")
        {
            isMoveActive = true;
        }


        randomSpot = Random.Range(0, moveSpots.Length);
    }
    void Update()
    {
        if (isMoveActive)
        {
          
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);


            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            return;
        }



    }

    //IEnumerator StartScale()
    //{
    //    minScale = transform.localScale;
    //    while (repeatable)
    //    {
    //        yield return RepeatLerp(minScale, maxScale, duration);
    //        yield return RepeatLerp(minScale, maxScale, duration);

    //    }
    //}

    //public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    //{
    //    float i = 0.0f;
    //    float rate = (1.0f / time) * speed;
    //    while (i < 1.0f)
    //    {
    //        i += Time.deltaTime * rate;
    //        transform.localScale = Vector3.Lerp(a, b, i);
    //        yield return null;

    //    }
    //}
}

