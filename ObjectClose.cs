using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Call events depending on weather target object is in range or out of range of trigger distance.
/// </summary>
public class ObjectClose : MonoBehaviour
{
    public GameObject targetObject;         //Referance to the target gameobject.
    public float triggerDistance = 3;       //Distance to trigger event.
    public UnityEvent onObjectInRange;      //Event called when player is in range. 
    public UnityEvent onObjectOutOfRange;   //Event called when player is out of range.


    private bool inRange;
    private bool outOfRange;


    private void Start()
    {
        //If no target gamobject set, camera gameobject will be used as target.
        targetObject = targetObject == null ? targetObject = Camera.main.gameObject : targetObject;
    }
    private void Update()
    {
        CheckTargetDistance();
    }



    private void CheckTargetDistance()
    {
        float dist = Vector3.Distance(targetObject.transform.position, gameObject.transform.position);


        if (dist < triggerDistance)
        {
            outOfRange = false;
            if (inRange == false)
            {
                inRange = true;

                TargetInRange();
            }
        }
        else
        {
            inRange = false;
            if (outOfRange == false)
            {
                outOfRange = true;

                TargetOutOfRange();
            }
        }
       
    }



    private void TargetInRange()
    {
        onObjectInRange.Invoke();
    }

    private void TargetOutOfRange()
    {
        onObjectOutOfRange.Invoke();
    }
}
