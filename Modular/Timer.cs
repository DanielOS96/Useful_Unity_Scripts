using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A timer that will invoke events on start and end of run.   
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_onTimerStart;
    [SerializeField]
    private UnityEvent m_onTimerEnd;

    /// <summary>
    /// Start the timer with a time.
    /// </summary>
    /// <param name="time">Time the timer will run for seconds.</param>
    public void StartTimer(float time)
    {
        StartCoroutine(Delay(time));
    }


    /// <summary>
    /// Cancel the timer.
    /// </summary>
    public void StopTimer()
    {
        StopAllCoroutines();
    }


    IEnumerator Delay(float d)
    {
        m_onTimerStart.Invoke();

        yield return new WaitForSeconds(d);

        m_onTimerEnd.Invoke();
    }

}
