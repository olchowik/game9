using UnityEngine;
using System.Collections;
/// <summary>
/// Class that handles shootimg logic.
/// </summary>
public class Shooter : MonoBehaviour {
    // Bullet bullet;
    [SerializeField]
    private float speed;
    private Creature target=null;
    [SerializeField]
    private float frequency = 1;

    public virtual void locateTarget() {
        target = null;
        shoot();
    }

    public virtual void shoot()
    {
       
        GameObject clone =Instantiate(GameController.instance.bullet, gameObject.transform.position,Quaternion.identity) as GameObject;
        //clone.AddComponent<DestroyOnColision>();
        // clone.GetComponent<Rigidbody2D>().AddForce(clone.transform.forward * speed);
        Debug.Log("isshooting");
    }
    // Use this for initialization
    void Start () {

        //Coroutine is likely a more efficient choice and would enable to change frequency
        InvokeRepeating("locateTarget",1f,frequency);
       Debug.Log("locateTarget");
    }
	
}
