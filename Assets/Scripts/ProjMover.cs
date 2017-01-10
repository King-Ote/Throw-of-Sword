using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjMover : UnitControl {

    protected Vector3 destination;
    protected bool singleDestCheck = true;
    
    // Use this for initialization
    void Start () {
        GetDestination(); //Can replace w/ singleDestCheck = true
    }

    public override void Move () {
        if (!singleDestCheck) {
            GetDestination();
        }
        Vector3 move = destination - transform.position;
        // Go in the direction of destination, unless closer then time*speed
        // If so, just snap to destination!
        if (move.magnitude > Time.deltaTime * speed) {
            transform.position += move.normalized * Time.deltaTime * speed;
        } else {
            transform.position = destination;
            Impact();
        }
        FlipSprite(move);
    }

    public virtual void GetDestination() {
        destination = transform.position;
    }

    public virtual void Impact () {
        Destroy(gameObject);
    }
}

