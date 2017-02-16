using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobboMover : HomingProjMover {
    
    public int score = 10;

    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.gameObject.CompareTag("PlayerProj")) {
            GameObject.Find("UI/ScoreTracker").SendMessage("AddScore", 10);
            Impact();
        }
    }
}
