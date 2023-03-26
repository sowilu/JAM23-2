using System;
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

    public void Init()
    {
        // find with tag
        var gos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoints = new List<Transform>();
        foreach (var go in gos)
        {
            spawnPoints.Add(go.transform);
        }
        SpawnRoutine();
    }


    private void Start()
    {
        Init();
    }

    private void Update()
    {
        spawnRate += spawnRateIncrease * Time.deltaTime;
    }


    async void SpawnRoutine()
    {
        while (!GameManager.Instance.gameEnd)
        {
            Spawn();
            await new WaitForSeconds(1 / spawnRate);
        }
    }

    
    void Spawn()
    {
        //remove null spawnd points
        spawnPoints.RemoveAll(x => x == null);
        if(spawnPoints.Count == 0)
        {
            var gos = GameObject.FindGameObjectsWithTag("SpawnPoint");
            spawnPoints = new List<Transform>();
            foreach (var go in gos)
            {
                spawnPoints.Add(go.transform);
            }
        }

        try
        {
            var pos = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
                    var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            
                    var obj = Instantiate(prefab, pos, transform.rotation);
                    
                    if(Player.inst != null)
                        obj.target = Player.inst.transform;
        }
        catch (Exception e)
        {
            print("Filed to spawn:" + e.Message);
            
            //kill all asynctasks
            
        }
        

    }
}
