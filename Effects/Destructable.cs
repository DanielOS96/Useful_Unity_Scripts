using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script spawns a destroyed gameobject and removes gameobject it is attached to.
/// </summary>
public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject m_destroyedVersion;  //The destroyed version prefab.


    /// <summary>
    /// Destroy this gameobject and instantiate new 'destroyed' version.
    /// </summary>
    /// <param name="lifeTime">Lifetime of instantiated version.</param>
    public void Destroy(float lifeTime = 3) 
    {
        Destroy(Instantiate(m_destroyedVersion, transform.position, transform.rotation),lifeTime);
        
        Destroy(gameObject);
    }


    

    
}
