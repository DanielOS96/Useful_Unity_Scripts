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
    public class GameObjectUnityEvent : UnityEvent<GameObject> {}

    public enum MoveType {move, rotate, both }

    public MoveType moveType = MoveType.move;   //The type of movement lerp that will be preformed.

    public Transform transfromToMove;           //The transform to apply the movements to.
    public Transform startTransform;            //The start position the transformToMove will begin its movement from.
    public Transform endTransform;              //The end position the transformToMove will end up at.
    public float movementTime;                  //The time in which the movement will take place over.
    public float delayBeforeMove;               //The delay before the movement is preformed after being called.
    public bool worldSpace = true;              //Weather to preform the move in world space or local space.

    [Header("Events")]
    public GameObjectUnityEvent onMovementStarted;        //Called once movement is started.
    public GameObjectUnityEvent onMovementComplete;       //Called once movement is completed.
    public GameObjectUnityEvent onRotationStarted;        //Called once rotation is started.
    public GameObjectUnityEvent onRotationCompleted;      //Called once rotation is completed.


    public GameObject GameObjectToMove
    {
        get
        {
            return transfromToMove.gameObject;
        }
        set
        {
            transfromToMove = value.transform;
            if (startTransform == null) startTransform = value.transform;
        }
    }
    public GameObject GameObjectStartPosition
    {
        get
        {
            return startTransform.gameObject;
        }
        set
        {
            startTransform = value.transform;
        }
    }
    public GameObject GameObjectEndPosition
    {
        get
        {
            return endTransform.gameObject;
        }
        set
        {
            endTransform = value.transform;
        }
    }


    /// <summary>
    /// Start the movement of the item.
    /// </summary>
    public void StartMovement()
    {
        if (worldSpace)
        {
            if (moveType == MoveType.move || moveType == MoveType.both)
                StartCoroutine(MoveOverSeconds(transfromToMove, startTransform.position, endTransform.position, movementTime, delayBeforeMove));

            if (moveType == MoveType.rotate || moveType == MoveType.both)
                StartCoroutine(RotateOverSeconds(transfromToMove, startTransform.rotation, endTransform.rotation, movementTime, delayBeforeMove));
        }
        else
        {
            if (moveType == MoveType.move || moveType == MoveType.both)
                StartCoroutine(MoveOverSeconds(transfromToMove, startTransform.localPosition, endTransform.localPosition, movementTime, delayBeforeMove));

            if (moveType == MoveType.rotate || moveType == MoveType.both)
                StartCoroutine(RotateOverSeconds(transfromToMove, startTransform.localRotation, endTransform.localRotation, movementTime, delayBeforeMove));
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
            if (worldSpace) objectToMove.position = Vector3.Lerp(start, end, (elapsedTime / seconds));
            else objectToMove.localPosition = Vector3.Lerp(start, end, (elapsedTime / seconds));


            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (worldSpace)objectToMove.position = end;
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
            if (worldSpace)objectToRotate.transform.rotation = Quaternion.Lerp(start, end, (elapsedTime / seconds));
            else objectToRotate.transform.localRotation = Quaternion.Lerp(start, end, (elapsedTime / seconds));


            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (worldSpace) objectToRotate.rotation = end;
        else objectToRotate.localRotation = end;

        onRotationCompleted.Invoke(objectToRotate.gameObject);
    }

}
