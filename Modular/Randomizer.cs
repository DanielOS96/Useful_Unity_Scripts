using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Randomizer : MonoBehaviour
{
    public List<UnityEvent> events = new List<UnityEvent>();


    private int randomListIndex;


    public void RandomEvent()
    {
        randomListIndex = Random.Range(0, events.Count);

        events[randomListIndex].Invoke();
    }


}
