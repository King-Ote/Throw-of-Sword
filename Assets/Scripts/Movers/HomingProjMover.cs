using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjMover : ProjMover {

	// Will now GetDestination() before every move
	void Start () {
		singleDestCheck = false;
	}
	
    public override void GetDestination() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) {
            destination = player.transform.position;   
        } else {
            destination = new Vector3 (transform.position.x, -5,
                transform.position.z);
        }
    } 
}
