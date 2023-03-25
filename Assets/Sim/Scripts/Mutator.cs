using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mutator : MonoBehaviour
{
    public UnityEvent<string> onMutate;
    
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
    
    public void Mutate(Spell spell)
    {
        if (spell == null) return;
        
        //TODO: check why item passes not null check but is still null here
        //try
        //{
            Mutate(spell.bodyPartPrefab, spell.bodyPartType);
            
            if (spell.mutation == Mutation.Endurance)
            {
                Mutate(spell.hpBoost, spell.maxHpBoost);
            }
            else if(spell.mutation == Mutation.Agility)
            {
                Mutate(spell.speedBoost);
            }
            else if(spell.mutation == Mutation.Attack)
            {
                Mutate(spell.meleeCooldownBoost, spell.rangeCooldownBoost, spell.specialCooldownBoost);
            }
            
            onMutate.Invoke($"Master, I have amassed {spell.description}");
        //}
        //catch(Exception){}
    }

    public void Mutate(float spellCooldownBoost = 0,float meleeCooldownBoost = 0, float rangeCooldownBoost = 0, float specialCooldownBoost = 0)
    {
        Player.inst.GetComponent<Wand>().coolDown += spellCooldownBoost;
        
        if(Player.inst.meleeAttack != null)
            Player.inst.meleeAttack.coolDown += meleeCooldownBoost;
        
        if(Player.inst.rangeAttack != null)
            Player.inst.rangeAttack.coolDown += rangeCooldownBoost;
        
        if(Player.inst.specialAttack != null)
            Player.inst.specialAttack.coolDown += specialCooldownBoost;
    }

    public void Mutate(GameObject prefab, BodyPartType type)
    {
        var containsPart = false;
        var bodyPart = Player.inst.bodyParts.Find(x => x.type == type);
        if (bodyPart.position.childCount > 0)
        {
            //disable all children
            foreach (Transform child in bodyPart.position)
            {
                //if child is the same as prefab activate it
                if (child.gameObject.name.Contains(prefab.name) || name.Contains(child.gameObject.name))
                {
                    containsPart = true;
                    break;
                }
                else
                {
                    Destroy(child.gameObject);
                }
            }
        }

        if (!containsPart)
        {
            var newPart = Instantiate(prefab, bodyPart.position);
            newPart.transform.localPosition = Vector3.zero;
            var attack = newPart.GetComponent<AttackBase>();

            if (attack != null)
            {
                //find out if its melee range or special and add it to players reference
                if (attack is MeleeAttack)
                {
                    Player.inst.meleeAttack = attack as MeleeAttack;
                }
                else if (attack is RangedAttack)
                {
                    Player.inst.rangeAttack = attack as RangedAttack;
                }
                else if (attack is SpecialAttack)
                {
                    Player.inst.specialAttack = attack as SpecialAttack;
                }
            }
            
            attack.StartAutoAttack();
        }
    }

    

    public void Mutate(int hp = 0, int maxHp = 0)
    {
        Player.inst.health.maxHp += maxHp;
        Player.inst.health.HP += hp;
    }
    
    public void Mutate(float speed = 0)
    {
        Player.inst.movement.speed += speed;

        if (Player.inst.movement.speed > 8) Player.inst.movement.speed = 8;
    }
}
