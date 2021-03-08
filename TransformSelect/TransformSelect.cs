using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
/// <summary>
/// Select an object over a certain time. 
/// <para>-Optional movement of object during the duration of the selection.</para>
/// <para>-Call OnSelected() to begin selection process.</para>
/// <para>-Call OnUnselected() to cancel selection process.</para>
/// <para>-Includes method to return to origin position.</para>
/// <para>-Oprion to disable other instances when selection complete.</para>
/// </summary>
public class TransformSelect : MonoBehaviour
{   
    [Header("Setup Variables")]
    [SerializeField]
    internal float m_timeToFinishSelect = 5;    //Time in seconds it will take to finish the selecting process.
    [SerializeField]
    internal bool m_disableOtherInstances;      //All other instances of the script will be disabled when this is clicked. This stops selection of other transform selects once one has been activated.

    [Header("Movement Variables")]
    [SerializeField]
    internal Transform m_targetTransform;       //The transform that the selection transform will begin moving to in its selection state.  
    [SerializeField]
    internal Transform m_transformToMove;       //The transform that will be moved.

    [Header("Events")]
    [SerializeField]
    internal UnityEvent m_onSelectEvent;        //The event that is called when the selection process begins.
    [SerializeField]
    internal UnityEvent m_onSelectingEvent;     //The event that is called when the selection process ends.
    [SerializeField]
    internal UnityEvent m_onUnSelectingEvent;   //The event that is called when the selection process is completed.

    private IEnumerator m_moveCoroutine;    //Referance to the move coroutine.
    private IEnumerator m_waitCoroutine;    //Referance to the move coroutine.
    private Vector3 m_originalPos;          //Original position of the transform.
    private Quaternion m_originalRot;       //Original rotation of the transform.
    private bool m_selectionComplete;       //True if the selection is complete.



    #region Setup
    private void Awake()
    {
        //--------Setup Positions-------------------------------------------
        if (m_transformToMove != null)
        {
            m_originalPos = m_transformToMove.position;
            m_originalRot = m_transformToMove.rotation;
        }
        //--------------------------------------------------------------------
        if(m_targetTransform!=null)m_targetTransform.gameObject.SetActive(false);
    }
    #endregion


    #region Selected Methods
    /// <summary>
    /// This method should be called when the selection object is begining its selection.
    /// Will exit if called when selection arelady complete.
    /// </summary>
    public void OnSelected()
    {
        if (m_selectionComplete) return;

        //If target is specified move to taget.
        if (m_transformToMove!=null && m_targetTransform != null)
        {
            if (m_moveCoroutine != null) StopCoroutine(m_moveCoroutine);
            m_moveCoroutine = MoveOverSeconds(m_transformToMove, m_targetTransform.position, m_targetTransform.rotation, m_timeToFinishSelect);
            StartCoroutine(m_moveCoroutine);
        }
        //Else just start a wait timer coroutine.
        else
        {
            if (m_waitCoroutine != null) StopCoroutine(m_waitCoroutine);
            m_waitCoroutine = WaitOverSeconds(m_timeToFinishSelect);
            StartCoroutine(m_waitCoroutine);
        }

        m_onSelectingEvent.Invoke();

        Debug.Log("Selecting: "+gameObject.name);

    }
    /// <summary>
    /// Should be called when the selection object is being unselected.
    /// Will exit if called when selection is already complete.
    /// </summary>
    public void OnUnselected()
    {
        if (m_selectionComplete) return;

        //If target is specified move to target.
        if (m_transformToMove != null && m_targetTransform != null)
        {
            //Stop and return to origin position.
            if (m_moveCoroutine != null) StopCoroutine(m_moveCoroutine);
            m_moveCoroutine = MoveOverSeconds(m_transformToMove, m_originalPos, m_originalRot, m_timeToFinishSelect / 2);
            StartCoroutine(m_moveCoroutine);
        }
        //Else stop the wait coroutine. 
        else
        {
            if (m_waitCoroutine != null) StopCoroutine(m_waitCoroutine);
        }

        m_onUnSelectingEvent.Invoke();

        Debug.Log("Unselecting: "+gameObject.name);

    }


    /// <summary>
    /// Re-enable selection and return to origin position.
    /// </summary>
    public void ResetAfterSelected()
    {
        if (m_transformToMove != null && m_targetTransform != null) 
        {
            StartCoroutine(ReturnToOriginPositionCoroutine());
        }
        else
        {
            m_selectionComplete = false;
        } 
    }

   
    // This method is called when the selection object has finished the selection process.
    // Will exit if already complete.
    // Calles corountine in order to add a delay before a level is loaded.
    private void OnSelectionComplete()
    {
        if (m_selectionComplete) return;
        m_selectionComplete = true;

        if (m_moveCoroutine != null) StopCoroutine(m_moveCoroutine);
        if (m_waitCoroutine != null) StopCoroutine(m_waitCoroutine);

        m_onSelectEvent.Invoke();
        //StartCoroutine(OnSelectionCompleteCoroutine());

        if (m_disableOtherInstances)
        {
            TransformSelect[] allInstances = FindObjectsOfType<TransformSelect>();
            foreach (TransformSelect scriptInstance in allInstances)
                if (scriptInstance.gameObject != gameObject) scriptInstance.enabled = false;
        }

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
        if (objectToMove.transform.position == m_targetTransform.position && objectToMove.transform.rotation == m_targetTransform.rotation) OnSelectionComplete();

    }

    //Wait seconds before selection is complete.
    private IEnumerator WaitOverSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        OnSelectionComplete();
    }


    //Return the transform to its origin position.
    private IEnumerator ReturnToOriginPositionCoroutine()
    {
        if (m_targetTransform != null && m_transformToMove != null)
        {
            yield return StartCoroutine(MoveOverSeconds(m_transformToMove, m_originalPos, m_originalRot, m_timeToFinishSelect / 2));
        }
        m_selectionComplete = false;
    }








}


