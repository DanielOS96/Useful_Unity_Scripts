using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script spawns a destroyed gameobject and removes gameobject it is attached to.
/// </summary>
public class Destructable : MonoBehaviour
{
    public GameObject destroyedVersion;


    public void Destroy(float lifeTime=3) {
        Destroy(Instantiate(destroyedVersion, transform.position, transform.rotation),lifeTime);
        
        Destroy(gameObject);
    }


    

    
}
