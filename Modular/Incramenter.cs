using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Incramenter : MonoBehaviour
{
    public int StoredValue { get => _storedValue; set => _storedValue = value; }

    [SerializeField]
    private TextMeshPro _textMesh;

    [SerializeField]
    private int targetValue;
    [SerializeField]
    private UnityEvent onTargetValueReached;

    private int _storedValue;

    public void Incrament(int value = 1)
    {
        _storedValue += value;

        if (_textMesh!=null)_textMesh.text = _storedValue.ToString();

        if (_storedValue == targetValue)
        {
            onTargetValueReached.Invoke();
        }
    }


}
