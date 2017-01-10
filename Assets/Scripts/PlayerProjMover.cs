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

    protected void OnTriggerEnter(Collider collider) {
        Debug.Log("WOW!!!");
        if (collider.gameObject.CompareTag("Enemy")) {
            Impact();
        }
    }

    public override void Impact () {
        Destroy(gameObject);
    }
}

