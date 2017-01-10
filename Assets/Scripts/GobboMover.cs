using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobboMover : HomingProjMover {
    
    void OnTriggerEnter (Collider collider) {
        Debug.Log("GOB DOWN!!");
        Destroy(gameObject);
    }
}
