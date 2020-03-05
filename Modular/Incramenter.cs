using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Incramenter : MonoBehaviour
{
    public TextMeshPro text;

    private int value;

    public void Incrament()
    {
        value++;
        text.text = value.ToString();
    }
}
