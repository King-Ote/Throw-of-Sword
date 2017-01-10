using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjSpawner : ProjSpawner {
    public override bool ReadyToFire() {
        return (Time.time - lastSpawnTime > spawnDelay) & Input.GetMouseButton (0);
    }
}
