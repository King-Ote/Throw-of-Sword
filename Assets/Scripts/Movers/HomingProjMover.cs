using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjMover : ProjMover {

	// Will now GetDestination() before every move
	void Start () {
		singleDestCheck = false;
        player = GameObject.FindGameObjectWithTag("Player");
	}
}
