using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour {

    public GameObject bgObject;
    public float spawnHeight = 0;
    public float minDelay = 0.01f;
    public float maxDelay = 0.3f;

    protected float initTime = 0f;
    protected float screenWidth = 0f;
    protected float screenHeight = 0f;
    protected float lastSpawnTime = 0f;
    protected float spawnDelay = 0f;
    protected float spawnXPos = 0f;
    protected Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
        screenWidth = GetComponent<Renderer>().bounds.size.x;
        screenHeight = GetComponent<Renderer>().bounds.size.y;
        lastSpawnTime = Time.time;
        initTime = lastSpawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		Spawn();
	}

    void Spawn () {
        if ((spawnDelay >= 0) & (Time.time - lastSpawnTime > spawnDelay)) {
            // Spawn a background item
            spawnXPos = Random.Range(-screenWidth/2f, screenWidth/2f);
            spawnPosition = new Vector3(spawnXPos,
                screenHeight/2f+0.5f, spawnHeight);
            Instantiate(bgObject, spawnPosition,
                new Quaternion(0f,0f,0f,0f), transform);

            // Prep for next spawn
            lastSpawnTime = Time.time;
            UpdateSpawnDelay();
        }
    }

    public virtual void UpdateSpawnDelay() {
        // Use this to disable spawning - won't spawn with spawnDelay < 0
        // Or just increase spawn rate as game goes on
        spawnDelay = Random.Range(minDelay, maxDelay);
    }
}
