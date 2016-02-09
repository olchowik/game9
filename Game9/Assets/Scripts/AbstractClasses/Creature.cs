using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour {
    public GameObject dieParticle;
    private float health=1;

    public float Health
    {
        get { return health; }
        //use deduceHealth instead of setter
        //set { health = value; }
    }

    public void deduceHealth(float amount)
    {
        health = health - amount;
        if (health <= 0) { die(); }
    }
    //Player and enemies need to die differently
    public abstract void die();
  
}
