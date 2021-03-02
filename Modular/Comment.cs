using UnityEngine;
/// <summary>
/// Attach this script to any GameObject on which you want to put a note.
/// </summary>
public class Comment : MonoBehaviour
{
#pragma warning disable CS0414
    [TextArea(0,100)]
    [SerializeField]
    private string m_notes = "Comment Here.";   //Enter your note in the Unity Editor.

#pragma warning restore CS0414
}