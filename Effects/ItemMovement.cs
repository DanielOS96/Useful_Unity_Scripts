using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script will:
/// <para>Rotate and bob the gameobject up and down.</para>
/// </summary>
public class ItemMovement : MonoBehaviour
{

    [Header("Movement Settings")]
    [Range(-10,10)]
    public float rotationSpeed = 5;         //The speed at which the item rotates.
    public float bobSpeed = 0.2f;           //The speed at which the item bobs up and down.
    public float bobDistanceMeters = 0.1f;  //The distance of the bob.

    public bool MoveOnStart = true;         //Start movement when the scene starts.


    void Start()
    {
        if (MoveOnStart) StartMovement();
    }


    /// <summary>
    /// Start the item moving.
    /// </summary>
    public void StartMovement()
    {
        StartCoroutine(Rotate());
        StartCoroutine(Bob());
    }

    /// <summary>
    /// Stop the item moving.
    /// </summary>
    public void StopMovment()
    {
        StopAllCoroutines();
    }


    #region Movement Coroutines

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(Vector3.up, rotationSpeed, Space.World);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator Bob()
    {

        Vector3 topPosition = new Vector3(transform.position.x, transform.position.y + bobDistanceMeters, transform.position.z);
        Vector3 bottomPosition = new Vector3(transform.position.x, transform.position.y - bobDistanceMeters, transform.position.z);

        while (true)
        {
            while (transform.position != bottomPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, bottomPosition, bobSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            while (transform.position != topPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, topPosition, bobSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
    #endregion
}
