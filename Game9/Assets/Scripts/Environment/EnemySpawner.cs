using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Coroutine that spawns Enemies at random interval at the position of one of the free Spawner objects.
/// </summary>
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
        //creates layer mask for Enemies
        enemiesLayer = 1 << LayerMask.NameToLayer("Enemies");
        //returns all objects that have spawner functionality
        allSpawners = (Spawner[]) GameObject.FindObjectsOfType(typeof(Spawner)); 
    }

   public void refreshFreeSpawners()
    {
        freeSpawners.Clear();
        foreach (Spawner s in allSpawners)
        {
            // Debug.Log(s);
            Collider2D overlapingColider = Physics2D.OverlapCircle(s.transform.position, 0.3f, enemiesLayer);
            //if therere is NO overlap between coliders on ENEMY layer and our spawner add it to freeSpawners
            if (overlapingColider == null)
            {
                freeSpawners.Add(s);
            }
        }
        Debug.Log("freeSpawners.Count" + freeSpawners.Count);
    }
    /// <summary>
    /// If there are free spawners picks random and makes it instantiate an Enemy.
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    IEnumerator SpawnObject(float seconds)
    {
        Debug.Log("Waiting for " + seconds + " seconds");
        //update info about free spawners 
        refreshFreeSpawners();

        if (freeSpawners.Count > 0)//if we have any free spawner
        {
            Spawner activeSpawner = freeSpawners[Random.Range(0, freeSpawners.Count)];//picks random free Spawner
            activeSpawner.spawnObject(Enemy);
        }
        yield return new WaitForSeconds(seconds);
       
        //We've spawned, so now we could start another spawn     
        isSpawning = false;
    }
    /// <summary>
    /// Srats spawning coroutine with randow dalay time
    /// </summary>
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
