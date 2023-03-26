using System;
using UnityEngine;

public class MelleeAttack : MonoBehaviour
{
    [Range(0f, 5f)] public float attackInterval;
    public int damage = 10;
    public Sound attackSound;
    public Bullet attackEffect;

    public void StartAttack() => AttackRoutine();

    async void AttackRoutine()
    {
        while (!GameManager.Instance.gameEnd)
        {
            await new WaitForSeconds(attackInterval);

            try
            {
                Attack();
            }
            catch (Exception)
            {
            }

        }
    }

    void Attack()
    {
        attackSound.Play();
        if (attackEffect)
        {
            var effect = Instantiate(attackEffect, transform.position, transform.rotation);
            effect.damage = damage;
        }
    }
}