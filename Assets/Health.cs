using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public static UnityEvent<int> onAnyDamage = new(); 
    
    [Min(1)] public int maxHp = 100;

    [Min(1)] [SerializeField] private int hp;

    [Header("Events")] UnityEvent onDie = new();
    UnityEvent<int> onDamage = new();

    [Header("Effects")] [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject damageEffect;
    public bool tweenOnDamage = true;

    public bool autoDestroy;


    private void Awake()
    {
        if (hp <= 0) hp = maxHp;
    }


    public int HP
    {
        get => hp;
        set
        {
            hp = value;

            var damage = hp - value;
            onDamage.Invoke(damage);
            onAnyDamage.Invoke(damage);
            if (tweenOnDamage) StartCoroutine(TweenRoutine());
            if (damageEffect) Instantiate(damageEffect, transform.position, transform.rotation);
            if (hp <= 0)
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
            if (deathEffect) Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}