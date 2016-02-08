using UnityEngine;
using System.Collections;
/// <summary>
/// Simple spawner
/// </summary>
public class Spawner : MonoBehaviour {
    /// <summary>
    /// Spawns object at Spawner position and rotation
    /// </summary>
    /// <param name="obj"></param>
    public void spawnObject(GameObject obj)
    {
        GameObject newObj = Instantiate(obj, transform.position, transform.rotation) as GameObject;
        newObj.layer = obj.layer;
    }
}
