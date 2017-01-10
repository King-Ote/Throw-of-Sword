using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : UnitControl {

    protected float xBound;
    protected float yBound;
    protected Vector3 newPos;

	// Use this for initialization
	void Start () {
        Vector3 bgSize = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size;
        xBound = bgSize.x/2f;
        yBound = bgSize.y/2f;
	}

    public override void Move () {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0f);
        newPos = transform.position + move * speed * Time.deltaTime;
        newPos.x = Mathf.Max(Mathf.Min(newPos.x, xBound), -xBound);
        newPos.y = Mathf.Max(Mathf.Min(newPos.y, yBound), -yBound);
        transform.position = new Vector3(newPos.x, newPos.y, newPos.z);

        FlipSprite(move);
    }
}
