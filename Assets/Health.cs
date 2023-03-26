using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Health : MonoBehaviour
{
    public static UnityEvent<int> onAnyDamage = new(); 
    
    [Min(1)] public int maxHp = 100;

    [Min(1)] [SerializeField] private int hp;

    [Header("Events")] 
    public UnityEvent onDie = new();
    public UnityEvent<int> onDamage = new();

    [Header("Effects")] 
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject damageEffect;
    [SerializeField] GameObject bloodPuddle;
    
    public bool tweenOnDamage = true;

    public bool autoDestroy;
    public bool bloodPoolOnDamage;


    private void Awake()
    {
        if (hp <= 0) hp = maxHp;
    }


    public int HP
    {
        get => hp;
        set
        {
            var damage = hp - value;
            onDamage.Invoke(damage);
            onAnyDamage.Invoke(damage);
            if(bloodPoolOnDamage && bloodPuddle!=null) Instantiate(bloodPuddle, transform.position + Vector3.up*0.02f, Quaternion.identity);
            try
            {
                if (gameObject.activeSelf && tweenOnDamage) StartCoroutine(TweenRoutine());
                if (damageEffect) Instantiate(damageEffect, transform.position, transform.rotation);
            }
            catch(Exception){}
            hp = value;
            if (hp <= 0f)
            {
                Die();
            }
            
  
            
            if (hp > maxHp)
            {
                hp = maxHp;
            }
        }
    }

    IEnumerator TweenRoutine()
    {
        for(float i = 1.3f; i > 1; i -= Time.deltaTime * 2)
        {
            transform.localScale = Vector3.one * i;
            yield return null;
        }
    }

    public void Die()
    {
        onDie.Invoke();

        if (autoDestroy)
        {
            if (deathEffect) 
                Instantiate(deathEffect, transform.position, transform.rotation);

            if (bloodPuddle)
                Instantiate(bloodPuddle, transform.position + Vector3.up*0.02f, Quaternion.Euler(90, Random.Range(0, 360), 0)).transform.localScale = new Vector3(Random.Range(0.9f, 1.8f), 1, Random.Range(0.9f, 1.8f));
            
            Destroy(gameObject);
        }
    }
}