using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Create a list of events and invoke one at random.  
/// </summary>
public class Randomizer : MonoBehaviour
{
    public List<UnityEvent> events = new List<UnityEvent>();


    private int m_randomListIndex;

    /// <summary>
    /// Chose a random event.
    /// </summary>
    public void RandomEvent()
    {
        m_randomListIndex = Random.Range(0, events.Count);

        events[m_randomListIndex].Invoke();
    }


}
