using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spowner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawnPoints;
    Randomazer randomazer;
   

    private int nowSprite;

    [SerializeField] private float timeBetweenSpawns;
    private float nextSpawnTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            randomazer = FindObjectOfType<Randomazer>();
            randomazer.GetRandom();
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
