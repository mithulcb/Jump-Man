using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timer;
    public Text score;
    public float time;
    public float points;
    float msec;
    float sec;
    float min;
    private Transform player;


    public void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine("StopWatch");
    }

    public void Stop_StopWatch()
    {
        StopCoroutine("StopWatch");
    }

    IEnumerator StopWatch()
    {
        while (true)
        {
            time += Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            points = (min*60 + sec) * 5  ;

            score.text = string.Format("{0}",points);
            timer.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);

            

            if (player==null)
            {
                Stop_StopWatch();
                yield return null;
            }

            player = GameObject.FindWithTag("Player").transform;

            yield return null;
        }
    }
}
