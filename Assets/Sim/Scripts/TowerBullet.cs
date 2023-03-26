using UnityEngine;


public class TowerBullet : MonoBehaviour
{
    public Transform target;
    public int damage = 15;
    public GameObject dieEffect;
    public float speed = 20;
    void Update()
    {
        if (target != null)
        {
            //roatte towards target
            //move towards target
            transform.LookAt(target);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (target != null && collision.transform.CompareTag(target.transform.tag))
        {
            //get health script, if not null deal damage, self destruct either way before hand display particles
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.HP -= damage;
                
                //print("DAMAGING "+ collision.transform.name);
            }
            
            if(dieEffect != null)
                Instantiate(dieEffect, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
 
        
        
    }
}
