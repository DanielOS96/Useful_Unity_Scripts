using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Spawn a prefab at a given transfrom.
/// </summary>
public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPos;
    public bool destroyObjAfterTime;
    public float timeBeforeDestroy;
    public Vector3 positionOffset;


    public GameObject Prefab
    {
        get => prefab;
        set => prefab = value;
    }
    


    GameObject spawnedObj;

    public void Spawn()
    {
        spawnPos = spawnPos == null ? transform: spawnPos;

        spawnedObj = Instantiate(prefab, spawnPos.position+positionOffset, spawnPos.rotation);

        if (destroyObjAfterTime)
        {
            Destroy(spawnedObj, timeBeforeDestroy);
        }
    }
}
