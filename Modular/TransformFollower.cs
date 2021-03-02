using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used to make a transform follow another via parenting or mimicing scale, rotation and position.
/// </summary>
public class TransformFollower : MonoBehaviour
{
    [SerializeField]
    private Transform m_transformToFollow; //The transform target that will be followed.
    [SerializeField]
    private bool m_parentOnStart = true;   //Parent the object rather then follow it.
    [SerializeField]
    private bool m_followPosition;         //Follow the transforms position.
    [SerializeField]
    private bool m_followRotation;         //Follow the transforms rotation.
    [SerializeField]
    private bool m_followScale;            //Follow the transforms scale.


    private void Start()
    {
        if (m_parentOnStart) transform.SetParent(m_transformToFollow);
    }

    private void Update()
    {
        if (m_parentOnStart) return;

        if (m_followPosition) transform.position = m_transformToFollow.position;
        if (m_followRotation) transform.rotation = m_transformToFollow.rotation;
        if (m_followScale) transform.localScale = m_transformToFollow.localScale;
    }
}
