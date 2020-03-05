using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class MyFloatEvent : UnityEvent<float> { }

public class DistanceFromObject : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();  //Targets to monitor.

    public float upperThreshold = 1.5f;     //Upper distance to calculate proxmity.
    public float lowerThreshold = 0.5f;     //Lower distance to calculate proximity
    public float triggerDistance = 1;       //Distance to trigger event.

    public UnityEvent onObjectInRange;      //Event called when player is in range. 
    public UnityEvent onObjectOutOfRange;   //Event called when player is out of range.
    public MyFloatEvent onProximityChanged; //Dyanmic event called when in proximity with a normalized proximity value.

    private bool inRange;
    private bool outOfRange;


    /// <summary>
    /// Add additional target object to list.
    /// </summary>
    /// <param name="target">Target object</param>
    public void SetTarget(GameObject target)
    {
        targets.Add(target);
    }


    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject t in targets)
        {
            if (t!=null)CheckTargetDistance(t.transform.position);
        }
    }

 



    private void CheckTargetDistance(Vector3 targetPos)
    {

        float targetDist = Vector3.Distance(transform.position,targetPos) - lowerThreshold;


        //Check if target in trigger istnace.
        if (targetDist < triggerDistance)
        {
            outOfRange = false;
            if (inRange == false)
            {
                inRange = true;
                onObjectInRange.Invoke();
            }
        }
        else
        {
            inRange = false;
            if (outOfRange == false)
            {
                outOfRange = true;
                onObjectOutOfRange.Invoke();
            }
        }



        //Call a dyanmic normalised proximity event.
        if (targetDist <= upperThreshold)
        {
            float normalisedValue = Mathf.Clamp( targetDist / upperThreshold,0,1);
            

            onProximityChanged.Invoke(normalisedValue);

            //Debug.Log(normalisedValue);
        }
        
        
    }




}
