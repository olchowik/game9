using UnityEngine;
using System.Collections;
/// <summary>
/// Class that handles shootimg logic.
/// </summary>
public abstract class Shooter : MonoBehaviour {
    public  Bullet bullet;
    [SerializeField]
    private float speed;
    private Creature target=null;
    [SerializeField]
    private float frequency = 1;

    public virtual void locateTarget() {
        target = null;
    }

    public virtual void shoot()
    {
        GameObject clone =Instantiate( bullet, gameObject.transform.position,Quaternion.identity) as GameObject;
        clone.GetComponent<Rigidbody2D>().AddForce(clone.transform.forward * speed);
    }
    // Use this for initialization
    void Start () {
        //Coroutine is likely a more efficient choice and would enable to change frequency
        InvokeRepeating("locateTarget",1f,frequency);
	}
	
}
