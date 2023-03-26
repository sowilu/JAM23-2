using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    public AudioClip sound;
    public float range;
    public string targetTag = "Player";

    public int damage = 10;
    public float coolDown = 5;
    public TowerBullet bullet;
    public Transform firePoint;
    private bool canShoot = true;

    private List<Transform> targets = new();
    private void Update()
    {
        targets.Clear();
        // target closest in overlap sphere
        var pos = transform.position;
        pos.y = 0;
        
        
        Collider[] colliders = Physics.OverlapSphere(pos, range);

        foreach (Collider collider in colliders)
        {
            if (collider.transform.CompareTag(targetTag))
            {
                //Debug.Log("Target found");
                targets.Add(collider.transform);
            }
        }

        Transform nearestTarget = null;
        if (targets.Count > 0)
        {
            //find nearest target
            float nearestDistance = Mathf.Infinity;
            
            foreach (Transform target in targets)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTarget = target;
                }
            }
        }
 
        
        if (nearestTarget != null)
        {
            //rotate on y axis towards nearest target + 90 degrees
            transform.localRotation = Quaternion.LookRotation(nearestTarget.position - transform.position) * Quaternion.Euler(0, -90, 0);
            
        }
        
        if (canShoot && nearestTarget != null)
        {
            Audio.Play(sound);
            try
            {
                var b = Instantiate(bullet, firePoint.position, Quaternion.identity);

                //print($"{transform.name} targeting {nearestTarget.name}");
                b.damage = damage;
                b.target = nearestTarget;

                canShoot = false;
                Invoke(nameof(CooledDown), coolDown);
            }
            catch (Exception)
            {
            }
        }
    }

    void CooledDown()
    {
        canShoot = true;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, range);
    }
#endif
}