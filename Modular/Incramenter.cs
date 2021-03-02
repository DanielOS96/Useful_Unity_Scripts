using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
/// <summary>
/// Increment towards the target value. Invoke event when target value is reached. 
/// </summary>
public class Incrementer : MonoBehaviour
{
    public int StoredValue { get => m_storedValue; set => m_storedValue = value; }

    [SerializeField]
    private TextMeshPro m_textMesh; //A text mesh output of the current value.

    [SerializeField]
    private int m_targetValue;  //The target value to reach.
    [SerializeField]
    private UnityEvent m_onTargetValueReached;  //Invoked when target value is reached.

    private int m_storedValue;  //The value that will be incramented to the target value.


    /// <summary>
    /// Increment towards the target value. 
    /// </summary>
    /// <param name="value">Value to increment by.</param>
    public void Increment(int value = 1)
    {
        m_storedValue += value;

        if (m_textMesh!=null)m_textMesh.text = m_storedValue.ToString();

        //Stored value must be exactly target value.
        if (m_storedValue == m_targetValue)
        {
            m_onTargetValueReached.Invoke();
        }
    }


}
