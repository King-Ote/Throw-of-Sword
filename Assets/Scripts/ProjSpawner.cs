using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSpawner : MonoBehaviour {

    public GameObject projectile;

    protected float lastSpawnTime = 0f;
    protected float spawnDelay = 0.5f;
    protected GameObject lastProjectile;

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (ReadyToFire()) {
            // Firreee!!!
            Vector3 spawnPos = new Vector3(transform.position.x,
                transform.position.y, 0f);
            lastProjectile = Instantiate(projectile, spawnPos,
                new Quaternion(0f,0f,0f,0f));
            // Prep for next spawn
            lastSpawnTime = Time.time;
        }
	}

    public virtual bool ReadyToFire() {
        return (Time.time - lastSpawnTime > spawnDelay);
    }
}
