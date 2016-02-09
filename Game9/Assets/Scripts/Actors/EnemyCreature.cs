using UnityEngine;
using System.Collections;

public class EnemyCreature : Creature {

    public override void die()
    {
        Instantiate(dieParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
