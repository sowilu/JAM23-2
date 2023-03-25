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
        //}
        //catch(Exception){}
    }

    public void Mutate(float spellCooldownBoost = 0,float meleeCooldownBoost = 0, float rangeCooldownBoost = 0, float specialCooldownBoost = 0)
    {
        Player.inst.GetComponent<Wand>().coolDown += spellCooldownBoost;
        Player.inst.meleeAttack.coolDown += meleeCooldownBoost;
        Player.inst.rangeAttack.coolDown += rangeCooldownBoost;
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
                if (child.gameObject.name.Contains(prefab.name))
                {
                    child.gameObject.SetActive(true);
                    containsPart = true;
                    onMutate.Invoke($"I don't need any more {prefab.name}");
                    break;
                }
                else
                {
                    child.gameObject.SetActive(false);
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
                //find out if its melee range or special and add it to players refference
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
            onMutate.Invoke($"I've grown {prefab.name}");
        }
    }

    

    public void Mutate(int hp = 0, int maxHp = 0)
    {
        Player.inst.health.maxHp += maxHp;
        Player.inst.health.HP += hp;

        var message = "";
        if (maxHp > 0)
            message += "I am feeling stronger";
        if(hp > 0)
            message += " I am feeling healthier";
        
        onMutate.Invoke(message);
    }
    
    public void Mutate(float speed = 0)
    {
        Player.inst.movement.speed += speed;

        var message = "";
        if (speed > 0)
            message += "I've become faster";
        if(speed < 0)
            message += "I've become slower";
        
        onMutate.Invoke(message);
    }
}
