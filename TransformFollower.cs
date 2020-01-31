using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used to make a gameobject follow another via parenting or mimicing transfrom rotation and position.
/// </summary>
public class TransformFollower : MonoBehaviour
{
    public Transform transformToFollow;
    public bool parentOnStart;
    public bool followPosition;
    public bool followRotation;
    public bool followScale;


    private void Start()
    {
        if (parentOnStart) transform.SetParent(transformToFollow);
    }

    private void Update()
    {
        if (parentOnStart) return;

        if (followPosition) transform.position = transformToFollow.position;
        if (followRotation) transform.rotation = transformToFollow.rotation;
        if (followScale) transform.localScale = transformToFollow.localScale;
    }
}
