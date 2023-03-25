using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public int damage = 10;
    public float coolDown;
    public bool canAttack = true;

    public void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            AttackAction();
            
            Invoke(nameof(CooledDown), coolDown);
        }
    }

    protected void CooledDown()
    {
        canAttack = true;
    }

    public virtual void AttackAction()
    {
        
    }
}
