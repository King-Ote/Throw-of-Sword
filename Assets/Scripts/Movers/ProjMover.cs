using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjMover : UnitControl {

    public GameObject splode; //What gets spawned when this explodes. Don't provide anything and it'll skip this

    protected GameObject player;
    public Vector3 destination;
    protected bool singleDestCheck = true;
    
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        GetDestination(); //Can replace w/ singleDestCheck = false to make it home
    }

    public override void Move () {
        if (!singleDestCheck) {
            GetDestination();
        }
        Vector3 move = destination - transform.position;
        // Go in the direction of destination, unless closer then time*speed
        // If so, just snap to destination!
        if (move.magnitude > Time.deltaTime * speed) {
            UpdatePosition(transform.position+move.normalized*speed*Time.deltaTime);
        } else {
            UpdatePosition(destination);
            Impact();
        }
        FlipSprite(move);
    }

    public virtual void GetDestination() {
        if (player) {
            destination = new Vector3 (player.transform.position.x,
                player.transform.position.y, transform.position.z);   
        } else {
            destination = new Vector3 (transform.position.x, -5,
                transform.position.z);
        }
    } 

    public virtual void Impact () {
        // rotation may not be all the way around z. wtf is a Quaternion?
        Quaternion newRotation = new Quaternion(0f, 0f, Random.Range(0f, Mathf.PI*2f), 1f);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        if (splode) {
            Instantiate(splode, newPosition, newRotation);
        }
        Destroy(gameObject);
    }
}

