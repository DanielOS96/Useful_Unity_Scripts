using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MoveObjectOverSpeed : MonoBehaviour
{
    public enum MoveType { move, rotate, both }

    public MoveType moveType = MoveType.move;   //The type of movement lerp that will be preformed.

    public Transform transfromToMove;           //The transform to apply the movements to.
    public Transform startTransform;            //The start position the transformToMove will begin its movement from.
    public Transform endTransform;              //The end position the transformToMove will end up at.
    public float moveSpeed=10;                  //The speed at which the movement will take place.
    public float rotationSpeed=100;             //The speed at which the rotation will take place.
    public float delayBeforeMove;               //The delay before the movement is preformed after being called.
    public bool worldSpace = true;              //Weather to preform the move in world space or local space.

    [Header("Events")]
    public MyGameobjectEvent onMovementStarted;        //Called once movement is started.
    public MyGameobjectEvent onMovementComplete;       //Called once movement is completed.
    public MyGameobjectEvent onRotationStarted;        //Called once rotation is started.
    public MyGameobjectEvent onRotationCompleted;      //Called once rotation is completed.

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


    public void StartMovement()
    {
        if (worldSpace)
        {
            if (moveType == MoveType.move || moveType == MoveType.both)
                StartCoroutine(MoveOverSpeed(transfromToMove, startTransform.position, endTransform.position, moveSpeed, delayBeforeMove));

            if (moveType == MoveType.rotate || moveType == MoveType.both)
                StartCoroutine(RotateOverSpeed(transfromToMove, startTransform.rotation, endTransform.rotation, rotationSpeed, delayBeforeMove));
        }
        else
        {
            if (moveType == MoveType.move || moveType == MoveType.both)
                StartCoroutine(MoveOverSpeed(transfromToMove, startTransform.localPosition, endTransform.localPosition, moveSpeed, delayBeforeMove));

            if (moveType == MoveType.rotate || moveType == MoveType.both)
                StartCoroutine(RotateOverSpeed(transfromToMove, startTransform.localRotation, endTransform.localRotation, rotationSpeed, delayBeforeMove));
        }
    }


    //Coroutine responsible for moving transform over speed.
    private IEnumerator MoveOverSpeed(Transform objectToMove, Vector3 start, Vector3 end, float speed, float delay)
    {
        float step = (speed / (start - end).magnitude) * Time.fixedDeltaTime;
        float t = 0;

        yield return new WaitForSeconds(delay);
        onMovementStarted.Invoke(objectToMove.gameObject);

        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            if (worldSpace)objectToMove.position = Vector3.Lerp(start, end, t); // Move objectToMove closer to b
            else objectToMove.localPosition = Vector3.Lerp(start, end, t);

            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        if (worldSpace) objectToMove.position = end;
        else objectToMove.localPosition = end;

        onMovementComplete.Invoke(objectToMove.gameObject);

    }


    //Coroutine responsible for rotating transform over speed.
    private IEnumerator RotateOverSpeed(Transform objectToRotate, Quaternion start, Quaternion end, float speed, float delay)
    {
        float step = (speed / (start.eulerAngles - end.eulerAngles).magnitude) * Time.fixedDeltaTime;
        float t = 0;

        yield return new WaitForSeconds(delay);
        onRotationStarted.Invoke(objectToRotate.gameObject);

        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            if (worldSpace) objectToRotate.rotation = Quaternion.Lerp(start, end, t); // Move objectToMove closer to b
            else objectToRotate.localRotation = Quaternion.Lerp(start, end, t);

            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        if (worldSpace)objectToRotate.rotation = end;
        else objectToRotate.localRotation = end;

        onRotationCompleted.Invoke(objectToRotate.gameObject);

    }


}
