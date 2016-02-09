using UnityEngine;
using System.Collections;
/// <summary>
/// This is how enemy dies
/// </summary>
public class EnemyCreature : Creature {

    public override void die()
    {
        Instantiate(dieParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
