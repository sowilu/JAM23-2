using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : AttackBase
{
    public GameObject specialProjectile;
    public float count = 5;
    public override void AttackAction()
    {
        //spawn 5 projectiles in random positions around layer
        for (int i = 0; i < count; i++)
        {
            var pos = transform.position + new Vector3(Random.Range(-5, 5), 20, Random.Range(-5, 5));
            Instantiate(specialProjectile, pos, transform.rotation);
        }
    }
}
