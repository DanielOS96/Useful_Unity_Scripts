using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    public UnityEvent onTimerStart;
    public UnityEvent onTimerEnd;


    public void StartTimer(float time)
    {
        StartCoroutine(Delay(time));
    }
    public void StopTimer()
    {
        StopAllCoroutines();
    }


    IEnumerator Delay(float d)
    {
        onTimerStart.Invoke();

        yield return new WaitForSeconds(d);

        onTimerEnd.Invoke();
    }

}
