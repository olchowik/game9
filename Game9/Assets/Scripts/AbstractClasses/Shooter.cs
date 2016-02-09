using UnityEngine;
using System.Collections;

public abstract class Shooter : MonoBehaviour {
    public  Bullet bullet;
    private Creature target=null;
    private float maxRange = 5;
    private RaycastHit hit;
    private bool active = true;
    [SerializeField]
    private float cooldown = 2;
    [SerializeField]
    private float frequency = 1;
    [SerializeField]
    private int noShots = 3;
    public virtual void locateTarget() {
       
    }
    public virtual void startShooting() {
        InvokeRepeating("shoot",0f, frequency);
        Invoke("stopShooting", (float)noShots * frequency);
    }
    public virtual void stopShooting()
    {
        CancelInvoke("shoot");
    }
    public virtual void shoot()
    {
        Instantiate( bullet, gameObject.transform.position,Quaternion.identity);

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (active) {
            locateTarget();
        }
	}
}
