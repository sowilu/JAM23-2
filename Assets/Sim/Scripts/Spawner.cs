using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 0.5f;
    public float spawnRateIncrease = 0.01f;

    public List<Enemy> enemyPrefabs;

    private List<Transform> spawnPoints;

    private void Awake()
    {
        // find with tag
        var gos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoints = new List<Transform>();
        foreach (var go in gos)
        {
            spawnPoints.Add(go.transform);
        }
    }


    void Start()
    {
        SpawnRoutine();
        
    }

    private void Update()
    {
        spawnRate += spawnRateIncrease * Time.deltaTime;
    }


    async void SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            await new WaitForSeconds(1 / spawnRate);
        }
    }

    
    void Spawn()
    {
        var pos = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        var obj = Instantiate(prefab, pos, transform.rotation);
        obj.target = Player.inst.transform;

    }
}
