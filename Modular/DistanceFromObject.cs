using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



/// <summary>
/// Check if target GameObject is within set range and invoke event.
/// <para> Call float event when within threshold of the GameObject.</para> 
/// </summary>
public class DistanceFromObject : MonoBehaviour
{

    [System.Serializable]
    private class MyFloatEvent : UnityEvent<float> { }

    [SerializeField]
    private List<GameObject> m_targets = new List<GameObject>();  //Targets to monitor.

    [SerializeField]
    private float m_upperThreshold = 1.5f;     //Upper distance to calculate proxmity.
    [SerializeField]
    private float m_lowerThreshold = 0.5f;     //Lower distance to calculate proximity.
    [SerializeField]
    private float m_triggerDistance = 1;       //Distance to trigger event.

    [SerializeField]
    private UnityEvent m_onObjectInRange;      //Event called when player is in range. 
    [SerializeField]
    private UnityEvent m_onObjectOutOfRange;   //Event called when player is out of range.
    [SerializeField]
    private MyFloatEvent m_onProximityChanged; //Dyanmic event called when in proximity with a normalized proximity value.

    private bool m_inRange;
    private bool m_outOfRange;


    /// <summary>
    /// Add additional target object to list.
    /// </summary>
    /// <param name="target">Target object</param>
    public void SetTarget(GameObject target)
    {
        m_targets.Add(target);
    }


    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject t in m_targets)
        {
            if (t!=null)CheckTargetDistance(t.transform.position);
        }
    }

 



    private void CheckTargetDistance(Vector3 targetPos)
    {

        float targetDist = Vector3.Distance(transform.position,targetPos) - m_lowerThreshold;


        //Check if target in trigger istnace.
        if (targetDist < m_triggerDistance)
        {
            m_outOfRange = false;
            if (m_inRange == false)
            {
                m_inRange = true;
                m_onObjectInRange.Invoke();
            }
        }
        else
        {
            m_inRange = false;
            if (m_outOfRange == false)
            {
                m_outOfRange = true;
                m_onObjectOutOfRange.Invoke();
            }
        }



        //Call a dyanmic normalised proximity event.
        if (targetDist <= m_upperThreshold)
        {
            float normalisedValue = Mathf.Clamp( targetDist / m_upperThreshold,0,1);
            

            m_onProximityChanged.Invoke(normalisedValue);

            //Debug.Log(normalisedValue);
        }
        
        
    }




}
