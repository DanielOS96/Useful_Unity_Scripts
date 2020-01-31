using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
/// <summary>
/// Script handles the selection of the transforms.
/// Effects and movement of the transforms are done in this script.
/// -Objects will be moved to a target transform over a space of time.
/// -Event is triggerd when transform is reached.
/// -Handles the effects presented on the move. Visual and Audio.
/// </summary>
public class TransformSelect : MonoBehaviour
{   
    [Header("Setup Variables")]
    public float timeToFinishSelect = 5;    //Time in seconds it will take to finish the selecting process.
    public float delayAfterSelected = 2;      //The delay after the selection is complete.
    public bool disableOtherInstances;      //All other instances of the script will be disabled when this is clicked.
    public string sceneToLoadName;          //The scene that will load when transform is fully selected.
    public UnityEvent onSelectEvent;        //The event that is called when the selection process begins.
    public UnityEvent onSelectDelayEvent;   //The event that is called when the selection process begins.
    public UnityEvent onSelectingEvent;     //The event that is called when the selection process ends.
    public UnityEvent onUnSelectingEvent;   //The event that is called when the selection process is completed.


    [Header("Movement Variables")]
    public Transform targetTransform;       //The transform that the selection transform will begin moving to in its selection state.  
    public Transform transformToMove;       //The transform that will be moved.


    protected IEnumerator moveCoroutine;    //Referance to the move coroutine.
    protected IEnumerator waitCoroutine;    //Referance to the move coroutine.
    protected Vector3 originalPos;          //Original position of the transform.
    protected Quaternion originalRot;       //Original rotation of the transform.
    protected bool selectionComplete;       //True if the selection is complete.



    #region Setup
    protected virtual void OnEnable()
    {
        //--------Setup Positions-------------------------------------------
        if (transformToMove != null)
        {
            originalPos = transformToMove.position;
            originalRot = transformToMove.rotation;
        }
        //--------------------------------------------------------------------
        if(targetTransform!=null)targetTransform.gameObject.SetActive(false);
    }
    protected virtual void OnDisable() { }
    #endregion


    #region Selected Methods
    /// <summary>
    /// This method should be called when the selection object is begining its selection.
    /// Will exit if called when selection arelady complete.
    /// </summary>
    public virtual void OnSelected()
    {
        if (selectionComplete) return;

        //If target is specified move to taget.
        if (transformToMove!=null && targetTransform != null)
        {
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = MoveOverSeconds(transformToMove, targetTransform.position, targetTransform.rotation, timeToFinishSelect);
            StartCoroutine(moveCoroutine);
        }
        //Else just start a wait timer coroutine.
        else
        {
            if (waitCoroutine != null) StopCoroutine(waitCoroutine);
            waitCoroutine = WaitOverSeconds(timeToFinishSelect);
            StartCoroutine(waitCoroutine);
        }

        onSelectingEvent.Invoke();

        Debug.Log("|||||||OnSelecting");

    }
    /// <summary>
    /// Should be called when the selection object is being unselected.
    /// Will exit if called when selection is already complete.
    /// </summary>
    public virtual void OnUnselected()
    {
        if (selectionComplete) return;

        //If target is specified move to target.
        if (transformToMove != null && targetTransform != null)
        {
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = MoveOverSeconds(transformToMove, originalPos, originalRot, timeToFinishSelect / 2);
            StartCoroutine(moveCoroutine);
        }
        //Else stop the wait coroutine. 
        else
        {
            if (waitCoroutine != null) StopCoroutine(waitCoroutine);
        }

        onUnSelectingEvent.Invoke();

        Debug.Log("|||||||OnUNSelecting");

    }
    /// <summary>
    /// This method is called when the selection object has finished the selection process.
    /// Will exit if already complete.
    /// Calles corountine in order to add a delay before a level is loaded.
    /// </summary>
    protected virtual void OnSelectionComplete()
    {
        if (selectionComplete) return;
        selectionComplete = true;

        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        if (waitCoroutine != null) StopCoroutine(waitCoroutine);

        onSelectEvent.Invoke();
        StartCoroutine(OnSelectionCompleteCoroutine());

        if (disableOtherInstances)
        {
            TransformSelect[] allInstances = FindObjectsOfType<TransformSelect>();
            foreach (TransformSelect scriptInstance in allInstances)
                if (scriptInstance.gameObject != gameObject) scriptInstance.enabled = false;
        }

    }
    private IEnumerator OnSelectionCompleteCoroutine()
    {
        yield return new WaitForSeconds(delayAfterSelected);

        if (!sceneToLoadName.Equals(""))
        {
            if (sceneToLoadName.Equals("Exit")) Application.Quit();
            Debug.Log("Loading..." + sceneToLoadName);
            SceneManager.LoadScene(sceneToLoadName); ;
        }


        //------Return object to origin for tidyness---------------------------------------------------
        yield return new WaitForSeconds(delayAfterSelected * 2);
        if (targetTransform !=null && transformToMove!=null) yield return StartCoroutine(MoveOverSeconds(transformToMove, originalPos, originalRot, timeToFinishSelect / 2));
        selectionComplete = false;
        //----------------------------------------------------------------------------------------------


        onSelectDelayEvent.Invoke();
    }
    #endregion





    //Move transfrom to target positoin.
    private IEnumerator MoveOverSeconds(Transform objectToMove, Vector3 end, Quaternion endRot, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        Quaternion startingRot = objectToMove.transform.rotation;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            objectToMove.transform.rotation = Quaternion.Lerp(startingRot, endRot, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        if (objectToMove.transform.position == targetTransform.position && objectToMove.transform.rotation == targetTransform.rotation) OnSelectionComplete();

    }

    //Wait seconds before selection is complete.
    private IEnumerator WaitOverSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        OnSelectionComplete();
    }









}


