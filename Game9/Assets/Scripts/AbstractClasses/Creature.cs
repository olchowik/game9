using UnityEngine;
using System.Collections;
/// <summary>
/// Everyone will die. This class is mainly about dying.
/// Also holds declares special effects for the funeral.
/// Sorry it's 05:44 am will rewrite docs later.
/// </summary>
public abstract class Creature : MonoBehaviour {
    public GameObject dieParticle;
    private float health=1;
    
    //fun with properties
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
