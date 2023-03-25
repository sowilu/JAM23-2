using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 0.1f;
    public Transform target;
    public float delay = 0.5f;
    public Enemy enemyPrefab;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), delay, 1f / spawnRate);
    }

    
    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation).target = target;
    }
}
