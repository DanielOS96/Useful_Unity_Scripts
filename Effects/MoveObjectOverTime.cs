using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Move or rotate an object over a given time.
/// </summary>
public class MoveObjectOverTime : MonoBehaviour
{
    [System.Serializable]
    private class GameObjectUnityEvent : UnityEvent<GameObject> { }

    private enum MoveType { move, rotate, both }


    [SerializeField]
    private MoveType m_moveType = MoveType.move;   //The type of movement lerp that will be preformed.

    [SerializeField]
    private Transform m_transfromToMove;           //The transform to apply the movements to.
    [SerializeField]
    private Transform m_startTransform;            //The start position the transformToMove will begin its movement from.
    [SerializeField]
    private Transform m_endTransform;              //The end position the transformToMove will end up at.
    [SerializeField]
    public float m_movementTime;                   //The time in which the movement will take place over.
    [SerializeField]
    private float m_rotationSpeed = 100;           //The speed at which the rotation will take place.
    [SerializeField]
    private float m_delayBeforeMove;               //The delay before the movement is preformed after being called.
    [SerializeField]
    private bool m_worldSpace = true;              //Weather to preform the move in world space or local space.

    [Header("Events")]
    [SerializeField]
    private GameObjectUnityEvent onMovementStarted;        //Called once movement is started.
    [SerializeField]
    private GameObjectUnityEvent onMovementComplete;       //Called once movement is completed.
    [SerializeField]
    private GameObjectUnityEvent onRotationStarted;        //Called once rotation is started.
    [SerializeField]
    private GameObjectUnityEvent onRotationCompleted;      //Called once rotation is completed.

    public GameObject GameObjectToMove
    {
        get
        {
            return m_transfromToMove.gameObject;
        }
        set
        {
            m_transfromToMove = value.transform;
            if (m_startTransform == null) m_startTransform = value.transform;
        }
    }
    public GameObject GameObjectStartPosition
    {
        get
        {
            return m_startTransform.gameObject;
        }
        set
        {
            m_startTransform = value.transform;
        }
    }
    public GameObject GameObjectEndPosition
    {
        get
        {
            return m_endTransform.gameObject;
        }
        set
        {
            m_endTransform = value.transform;
        }
    }

    /// <summary>
    /// Start the movement of the item.
    /// </summary>
    public void StartMovement()
    {
        if (m_worldSpace)
        {
            if (m_moveType == MoveType.move || m_moveType == MoveType.both)
                StartCoroutine(MoveOverSeconds(m_transfromToMove, m_startTransform.position, m_endTransform.position, m_movementTime, m_delayBeforeMove));

            if (m_moveType == MoveType.rotate || m_moveType == MoveType.both)
                StartCoroutine(RotateOverSeconds(m_transfromToMove, m_startTransform.rotation, m_endTransform.rotation, m_movementTime, m_delayBeforeMove));
        }
        else
        {
            if (m_moveType == MoveType.move || m_moveType == MoveType.both)
                StartCoroutine(MoveOverSeconds(m_transfromToMove, m_startTransform.localPosition, m_endTransform.localPosition, m_movementTime, m_delayBeforeMove));

            if (m_moveType == MoveType.rotate || m_moveType == MoveType.both)
                StartCoroutine(RotateOverSeconds(m_transfromToMove, m_startTransform.localRotation, m_endTransform.localRotation, m_movementTime, m_delayBeforeMove));
        }
    }

    //Coroutine responsible for moving transform over seconds.
    private IEnumerator MoveOverSeconds(Transform objectToMove, Vector3 start ,Vector3 end, float seconds, float delay)
    {
        float elapsedTime = 0;

        yield return new WaitForSeconds(delay);
        onMovementStarted.Invoke(objectToMove.gameObject);

        while (elapsedTime < seconds)
        {
            if (m_worldSpace) objectToMove.position = Vector3.Lerp(start, end, (elapsedTime / seconds));
            else objectToMove.localPosition = Vector3.Lerp(start, end, (elapsedTime / seconds));


            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (m_worldSpace) objectToMove.position = end;
        else objectToMove.localPosition = end;

        onMovementComplete.Invoke(objectToMove.gameObject);
    }

    //Coroutine responsible for rotating transform over seconds.
    private IEnumerator RotateOverSeconds(Transform objectToRotate, Quaternion start, Quaternion end, float seconds, float delay)
    {
        float elapsedTime = 0;

        yield return new WaitForSeconds(delay);
        onRotationStarted.Invoke(objectToRotate.gameObject);

        while (elapsedTime < seconds)
        {
            if (m_worldSpace) objectToRotate.transform.rotation = Quaternion.Lerp(start, end, (elapsedTime / seconds));
            else objectToRotate.transform.localRotation = Quaternion.Lerp(start, end, (elapsedTime / seconds));


            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (m_worldSpace) objectToRotate.rotation = end;
        else objectToRotate.localRotation = end;

        onRotationCompleted.Invoke(objectToRotate.gameObject);
    }

}
