using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfProjMover : ProjMover {

    public override void GetDestination() {
        if (player) {
            Vector3 toPlayer = new Vector3 (player.transform.position.x,
                player.transform.position.y, 0).normalized*5;
            toPlayer.z = transform.position.z;
            destination = toPlayer;
        } else {
            destination = new Vector3 (transform.position.x, -5,
                transform.position.z);
        }
    } 
}
