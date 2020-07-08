using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Stopwatch to measure the amount of time elapsed in seconds.
/// </summary>
public class Stopwatch : MonoBehaviour
{
    [System.Serializable]
    public class MyIntEvent : UnityEvent<int> { }

    public UnityEvent onStopwatchStart;
    public MyIntEvent onStopwatchStop;

    private bool isActive;
    private float elapsedTime;


    public void StartStopwatch()
    {
        isActive = true;
    }

    public void StopStopwatch()
    {
        isActive = false;

        int secondsElapsed = (int)elapsedTime;


        //Debug.Log(secondsElapsed);

        onStopwatchStop.Invoke(secondsElapsed);
    }

    private void Update()
    {
        if (isActive)
        {
            elapsedTime += Time.deltaTime;
        }
    }


}
