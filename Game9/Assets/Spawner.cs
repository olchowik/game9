using UnityEngine;
using System.Collections;
/// <summary>
/// Simple object spawner.
/// </summary>
public class Spawner : MonoBehaviour {
    /// <summary>
    /// Spawns clone of the parameter objectt Spawner position and rotation.
    /// Sets up layer of the new object to parameter obect layer.
    /// </summary>
    /// <param name="obj"></param>
    public void spawnObject(GameObject obj)
    {
        GameObject newObj = Instantiate(obj, transform.position, transform.rotation) as GameObject;
        newObj.layer = obj.layer;
    }
}
