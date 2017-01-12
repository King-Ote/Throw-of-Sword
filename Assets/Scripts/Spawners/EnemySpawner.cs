using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BGSpawner {

    public float speedupRate = 0.01f;

    public override void UpdateSpawnDelay () {
        float speedup = speedupRate * (Time.time - initTime);
        spawnDelay = Mathf.Max(Random.Range(minDelay, maxDelay) - speedup, 0);
    }
}
