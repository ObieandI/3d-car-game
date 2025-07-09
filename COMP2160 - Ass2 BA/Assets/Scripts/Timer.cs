using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float time;
    private float milliSec;
    private float sec;
    private float min;

    void Start()
    {
        StartCoroutine("StopWatch");
    }

    IEnumerator StopWatch()
    {
        while(true)
        {
            time += Time.deltaTime;
            milliSec = (int) ((time - (int) time) * 100);
            sec = (int) (time % 60);
            min = (int) (time/60 % 60);

            timer.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, milliSec);

            yield return null;
        }
    }

    public float GetMin()
    {
        return min;
    }

    public float GetSec()
    {
        return sec;
    }

    public float GetMilliSec()
    {
        return milliSec;
    }
}
