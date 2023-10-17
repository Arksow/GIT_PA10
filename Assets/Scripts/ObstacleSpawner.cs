﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the spawning of obstacles
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Obstacle = null;
    [SerializeField] private float SpawnInterval = 1;
    private float NextSpawn = 0;

    void Update()
    {
        if(Time.time >= NextSpawn)
        {
            NextSpawn = Time.time + SpawnInterval;
            Vector3 SpawnPos = new Vector3(8, Random.Range(-3, 3), 0);

            Instantiate(Obstacle, SpawnPos, Quaternion.identity);
        }
    }
}
