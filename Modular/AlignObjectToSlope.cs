using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Align game object to the surface normals it is on. 
/// </summary>
public class AlignObjectToSlope : MonoBehaviour
{
    public Transform transformToAlign;  //The transform that will be aligned.
    public float alignSpeed = 20;       //The speed at which the alignment takes place.


    private Quaternion slopeRotation;   //The rotation alligned to the surface normal.
    private Quaternion yRemovedLocal;   //The local rotation with a zerod y axis.

    private void Awake()
    {
        //------SetUp Referances-------------------------------------------------------------------
        transformToAlign = transformToAlign == null ? GetComponent<Transform>() : transformToAlign;
        //-----------------------------------------------------------------------------------------
    }

    private void FixedUpdate()
    {
        Align(transformToAlign);
    }



    //Preform the alignment.
    private void Align(Transform _transfromToAlign)
    {
        //declare a new Ray. It will start at this object's position and it's direction will be straight down from the object (in local space, that is)
        Ray ray = new Ray(transform.position, -transform.up);
        //decalre a RaycastHit. This is neccessary so it can get "filled" with information when casting the ray below.
        RaycastHit hit;

        //cast the ray. Note the "out hit" which makes the Raycast "fill" the hit variable with information. The maximum distance the ray will go is 1.5
        if (Physics.Raycast(ray, out hit, 0.5f) == true)
        {
            //draw a Debug Line so we can see the ray in the scene view.
            Debug.DrawLine(_transfromToAlign.position, hit.point, Color.green);


            //store the roation and position as they would be aligned on the surface
            slopeRotation = Quaternion.FromToRotation(_transfromToAlign.up, hit.normal) * _transfromToAlign.rotation;


            //smoothly rotate and move the objects until it's aligned to the surface.
            _transfromToAlign.rotation = Quaternion.Slerp(_transfromToAlign.rotation, slopeRotation, Time.deltaTime * alignSpeed);

            //New rotation with no y axis value.
            yRemovedLocal = new Quaternion(_transfromToAlign.localRotation.x, 0, _transfromToAlign.localRotation.z, _transfromToAlign.localRotation.w);

            //Set rotation to zero y axis variable.
            _transfromToAlign.localRotation = yRemovedLocal;
        }


    }

}
