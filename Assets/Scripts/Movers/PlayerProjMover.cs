using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjMover : ProjMover {

    public override void GetDestination() {
        var tempDest = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, 0);
        tempDest = Camera.main.ScreenToWorldPoint(tempDest);
        destination = new Vector3(tempDest.x, tempDest.y,
            transform.position.z);
    }

    /* Should probably have this eventually?
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Enemy")) {
            Impact();
        }
    }
    */
}

