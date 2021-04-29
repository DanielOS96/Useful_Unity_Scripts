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
    private class GameObjectUnityEvent : UnityEvent<GameObject> { }

    [SerializeField]
    private GameObject m_prefabToSpawn;    //The prefab to spawn.
    [SerializeField]
    private Transform m_spawnPosition;     //Position to spawn the prefab.
    [SerializeField]
    private Vector3 m_spawnPositionOffset; //Spawn position offset.
    [SerializeField]
    private GameObjectUnityEvent m_onPrefabSpawned;  //Event called after prefab is spawned.


    public GameObject PrefabToSpawn     //Property to set the prefab value.
    {
        get => m_prefabToSpawn;
        set => m_prefabToSpawn = value;
    }
    public Transform SpawnPosition      //Property to set spawn position.
    {
        get => m_spawnPosition;
        set => m_spawnPosition = value;
    }
    public Vector3 SpawnPositionOffset  //Property to set spawn position offset.
    {
        get => m_spawnPositionOffset;
        set => m_spawnPositionOffset = value;
    }



    /// <summary>
    /// Spawn a Prefab at specific location.
    /// </summary>
    public void Spawn()
    {
        //If spawn position is null spawn at current position.
        m_spawnPosition = m_spawnPosition == null ? transform : m_spawnPosition;

        GameObject spawnedObj = Instantiate(m_prefabToSpawn, m_spawnPosition.position + m_spawnPositionOffset, m_spawnPosition.rotation);

        //Invoke event and pass the GameObject referance.
        m_onPrefabSpawned.Invoke(spawnedObj);

    }
}
