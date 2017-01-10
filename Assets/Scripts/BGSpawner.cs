using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour {

    public GameObject bgObject;
    public float minDelay = 0.01f;
    public float maxDelay = 0.3f;

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
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastSpawnTime > spawnDelay) {
            // Spawn a background item
            spawnXPos = Random.Range(-screenWidth/2f, screenWidth/2f);
            spawnPosition = new Vector3(spawnXPos, screenHeight/2f+0.5f, 0f);
            Instantiate(bgObject, spawnPosition, new Quaternion(0f,0f,0f,0f),
                transform);

            // Prep for next spawn
            lastSpawnTime = Time.time;
            spawnDelay = Random.Range(0.01f, 0.3f);
        }
	}
}
