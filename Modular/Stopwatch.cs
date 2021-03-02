using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Stopwatch to measure the amount of time elapsed in seconds.
/// <para>Invoke an event on stop with the elapsed time.</para>
/// </summary>
public class Stopwatch : MonoBehaviour
{
    [System.Serializable]
    private class MyIntEvent : UnityEvent<int> { }

    [SerializeField]
    private UnityEvent m_onStopwatchStart;
    [SerializeField]
    private MyIntEvent m_onStopwatchStop;

    private bool m_isActive;
    private float m_elapsedTime;


    public void StartStopwatch()
    {
        m_isActive = true;
        m_onStopwatchStart.Invoke();
    }

    public void StopStopwatch()
    {
        m_isActive = false;

        int secondsElapsed = (int)m_elapsedTime;


        //Debug.Log(secondsElapsed);

        m_onStopwatchStop.Invoke(secondsElapsed);
    }

    private void Update()
    {
        if (m_isActive)
        {
            m_elapsedTime += Time.deltaTime;
        }
    }


}
