using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script will:
/// -Project a ray from a gameobject.
/// -If the ray hits a valid layer check for a 'TransformSelectTrigger' and
/// call the OnRayEnter or OnRayExit method respectivly.
/// </summary>
public class DrawRaycast : MonoBehaviour {

    public LayerMask layersToTarget;        //The layers the raycast will react to.

    Collider currentCollider;               //Referance to the most recently detected collider.
    bool hovering;                          //Weather or not the raycast is currently hovering on an valid gameobject.


    private void Update ()
    {

        RaycastHit hitPoint;
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hitPoint, Mathf.Infinity, layersToTarget))
        {
            Debug.DrawRay(ray.origin, ray.direction * hitPoint.distance, Color.green);
            
            if (!hovering && hitPoint.collider != null)
            {
                hovering = true;

                currentCollider = hitPoint.collider;

                TransformSelectTrigger hitReciver = currentCollider.gameObject.GetComponent<TransformSelectTrigger>();
                if (hitReciver != null) hitReciver.OnRayEnter();
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            
            if (hovering)
            {
                hovering = false;

                TransformSelectTrigger hitReciver = currentCollider.gameObject.GetComponent<TransformSelectTrigger>();
                if (hitReciver != null) hitReciver.OnRayExit();
            }
        }
    }


}
