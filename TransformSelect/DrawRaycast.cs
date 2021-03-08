using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Project a ray from this gameobject.
/// If the ray hits a collider with 'TransformSelectTrigger.cs'
/// call the OnRayEnter or OnRayExit method respectivly.
/// </summary>
public class DrawRaycast : MonoBehaviour {

    [SerializeField]
    private LayerMask m_layersToTarget;        //The layers the raycast will react to.

    private Collider m_currentCollider;               //Referance to the most recently detected collider.
    private bool m_hovering;                          //Weather or not the raycast is currently hovering on an valid gameobject.


    private void Update ()
    {

        RaycastHit hitPoint;
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hitPoint, Mathf.Infinity, m_layersToTarget))
        {
            Debug.DrawRay(ray.origin, ray.direction * hitPoint.distance, Color.green);
            
            if (!m_hovering && hitPoint.collider != null)
            {
                m_hovering = true;

                m_currentCollider = hitPoint.collider;

                TransformSelectTrigger hitReciver = m_currentCollider.gameObject.GetComponent<TransformSelectTrigger>();
                if (hitReciver != null) hitReciver.OnRayEnter();
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            
            if (m_hovering)
            {
                m_hovering = false;

                TransformSelectTrigger hitReciver = m_currentCollider.gameObject.GetComponent<TransformSelectTrigger>();
                if (hitReciver != null) hitReciver.OnRayExit();
            }
        }
    }


}
