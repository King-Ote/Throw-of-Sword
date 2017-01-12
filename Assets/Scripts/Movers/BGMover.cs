using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : UnitControl {

    ///protected float oob = 0f; // Out Of Bounds - y value when offscreen 

	// Use this for initialization
	void Start () {
		transform.GetComponent<SpriteRenderer>().sprite = baseSprites[Random.Range (0, baseSprites.Length-1)];
    	baseSprites = new Sprite[0];
    }
}
