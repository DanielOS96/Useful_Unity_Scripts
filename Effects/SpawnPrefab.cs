using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Spawn a prefab at a given transfrom.
/// </summary>
public class SpawnPrefab : MonoBehaviour
{
    [System.Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject>{}


    public GameObject prefab;           //Prefab to spawn.
    public Transform spawnPosition;     //Position to spawn the prefab.
    public Vector3 spawnPositionOffset; //Spawn position offset.

    public GameObjectUnityEvent onPrefabSpawned;  //Event called after prefab is spawned.


    public GameObject PrefabToSpawn     //Property to set the prefab value.
    {
        get => prefab;
        set => prefab = value;
    }
    public Transform SpawnPosition      //Property to set spawn position.
    {
        get => spawnPosition;
        set => spawnPosition = value;
    }
    public Vector3 SpawnPositionOffset  //Property to set spawn position offset.
    {
        get => spawnPositionOffset;
        set => spawnPositionOffset = value;
    }



    /// <summary>
    /// Spawn a Prefab at specific location.
    /// </summary>
    public void Spawn()
    {
        //If spawn position is null spawn at current position.
        spawnPosition = spawnPosition == null ? transform : spawnPosition;

        GameObject spawnedObj = Instantiate(prefab, spawnPosition.position+spawnPositionOffset, spawnPosition.rotation);

        //Invoke event and pass the GameObject referance.
        onPrefabSpawned.Invoke(spawnedObj); 

    }
}
