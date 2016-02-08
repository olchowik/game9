using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    bool isSpawning = false;
    [SerializeField] float minTime = 5.0f;
    [SerializeField] float maxTime = 15.0f;
    [SerializeField] GameObject Enemy;
    Spawner[] allSpawners; //for fixed number of spawners on the scene
    List<Spawner> freeSpawners = new List<Spawner>();

    private LayerMask enemiesLayer;
    /// <summary>
    /// Finds in the scene returns all objects that have Spawner functionality
    /// </summary>
    void Start() {
        enemiesLayer = 1 << LayerMask.NameToLayer("Enemies");
        allSpawners=(Spawner[]) GameObject.FindObjectsOfType(typeof(Spawner)); //returns all objects that have spawner functionality
        //freeSpawners = allSpawners;//all spawners are initially free
    }

    IEnumerator SpawnObject(float seconds)
    {
        Debug.Log("Waiting for " + seconds + " seconds");
        //update info about free spawners 

        freeSpawners.Clear();
        foreach (Spawner s in allSpawners)
        {
           // Debug.Log(s);
            Collider2D[] overlapingColiders = Physics2D.OverlapCircleAll(s.transform.position, 0.3f, enemiesLayer);
            Debug.Log("overlapingColiders.Length");
            Debug.Log(overlapingColiders.Length);
            //if therere is NO overlap between coliders on ENEMY layer and our spawner add it to freeSpawners
            if (overlapingColiders.Length == 0)
            {
              
                freeSpawners.Add(s);
            }
        }
        Debug.Log("freeSpawners.Count");
        Debug.Log(freeSpawners.Count);
        if (freeSpawners.Count > 0)//if we have any free spawner
        {
            Spawner activeSpawner = freeSpawners[Random.Range(0, freeSpawners.Count)];//picks random free Spawner
            activeSpawner.spawnObject(Enemy);
        }

        yield return new WaitForSeconds(seconds);
       

        //We've spawned, so now we could start another spawn     
        isSpawning = false;
    }

    void Update()
    {
        //We only want to spawn one at a time, so make sure we're not already making that call
        if (!isSpawning)
        {
            isSpawning = true; //Yep, we're going to spawn
            StartCoroutine(SpawnObject(Random.Range(minTime, maxTime)));
        }
    }
}
