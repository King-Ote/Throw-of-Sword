using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobboMover : HomingProjMover {
    
    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.gameObject.CompareTag("PlayerProj")) {
            Impact();
        }
    }
}
