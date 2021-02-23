using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;
    private float _spawnTime;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private Transform[] destinationPoints;

    [SerializeField]
    private float tick;
    [SerializeField]
    private float decreaseSpawnTimePerTick;

    private float _tick;
  
    void Start()
    {
        _spawnTime = spawnTime;
        _tick = tick;
        
    }

   
    void Update()
    {
        spawnTime -= Time.deltaTime;
        tick  -= Time.deltaTime;

        if(spawnTime<=0)
        {
            Spawn();           
            spawnTime = _spawnTime;
        }

        if(tick<=0)
        {
            tick = _tick;
            _spawnTime -= decreaseSpawnTimePerTick;

        }
    }

    private void Spawn()
    {
       GameObject enemy = Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        enemy.GetComponent<Enemy>().SetDestinationPosition(destinationPoints[Random.Range(0, destinationPoints.Length)].position);
    }
}
