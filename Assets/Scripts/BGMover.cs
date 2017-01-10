using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : UnitControl {

    ///protected float oob = 0f; // Out Of Bounds - y value when offscreen 

	// Use this for initialization
	void Start () {
	   //oob = -1f*transform.parent.GetComponent<SpriteRenderer>().bounds.size.y/2f-0.5f;
	   transform.GetComponent<SpriteRenderer>().sprite = baseSprites[Random.Range (0, baseSprites.Length-1)];
    }
	
	public override void Animate () {
		// Our backgrounds aren't animated atm,
		// so we need to override the base Animation call
	}
}
