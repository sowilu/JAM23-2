using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutator : MonoBehaviour
{
    public static Mutator inst;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Mutate(int hp = 0, int maxHp = 0)
    {
        if(maxHp != 0)
        {
            Pet.inst.health.maxHp += maxHp;
        }

        if (hp != 0)
        {
            Pet.inst.health.HP += hp;
        }
    }
}
