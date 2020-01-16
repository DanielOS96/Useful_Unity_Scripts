using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// This script will:
/// -Take a string of textmesh.
/// -Reveal one character at a time
/// based on the 'charRevealRate' variable
/// -Unreveal the text based on the same variable.
/// </summary>
public class TextMeshProScrollEffect : MonoBehaviour
{


    public TextMeshProUGUI textMesh;        //Referance to the textmeshpro text to use.
    public float charRevealRate = 0.1f;     //The letter reveal rate in seconds.
    public bool revealOnAwake;              //Enable this to reveal text when scene starts.

    int currentcCharIndex;                  //The last letter that has been revealed.

    private void Start()
    {
        if (revealOnAwake) RevealText();
    }



    #region Control Methods
    public void RevealText()
    {
        StopAllCoroutines();
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(RevealTextCoroutine());
        }
    }


    public void UnRevealText()
    {
        StopAllCoroutines();
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(UnRevealTextCoroutine());
        }
    }
    #endregion





    /// <summary>
    /// Reveal one letter at a time on a string of text.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RevealTextCoroutine()
    {
        textMesh.ForceMeshUpdate();

        int numOfChars = textMesh.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (numOfChars + 1);
            textMesh.maxVisibleCharacters = visibleCount;

            currentcCharIndex = visibleCount;

            Debug.Log("R" + numOfChars);


            if (visibleCount >= numOfChars) yield break;


            counter += 1;

            yield return new WaitForSeconds(charRevealRate);
        }

    }

    /// <summary>
    /// Remove one letter at a time from the string of text 
    /// </summary>
    /// <returns></returns>
    private IEnumerator UnRevealTextCoroutine()
    {
        int counter = currentcCharIndex;

        while (true)
        {
            currentcCharIndex = counter;

            textMesh.maxVisibleCharacters = currentcCharIndex;

            if (currentcCharIndex <= 0) yield break;


            counter -= 1;

            yield return new WaitForSeconds(charRevealRate);
        }
    }



}
