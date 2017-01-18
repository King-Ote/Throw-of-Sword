using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : UnitControl {

    public float jumpDuration = 0.75f;
    public List<Sprite> jumpSprite = new List<Sprite> (1);

    protected float xBound;
    protected float yBound;
    protected Vector3 newPos;
    protected bool isJumping = false;
    protected float jumpStartTime = 0f;

	// Use this for initialization
	void Start () {
        Vector3 bgSize = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size;
        xBound = bgSize.x/2f;
        yBound = bgSize.y/2f;
	}

    public override void Move () {
        if ((isJumping) | Input.GetKeyDown ("space")) {
            Jump();
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0f);
        newPos = transform.position + move * speed * Time.deltaTime;
        newPos.x = Mathf.Max(Mathf.Min(newPos.x, xBound), -xBound);
        newPos.y = Mathf.Max(Mathf.Min(newPos.y, yBound), -yBound);
        UpdatePosition(new Vector3(newPos.x, newPos.y, newPos.z));
        
        FlipSprite(move);
    }

    void Jump () {
        // TODO: Turn shooting off and on
        if (!isJumping) {
            // Start a jump
            usedSprites = new List<Sprite>(jumpSprite);
            gameObject.GetComponent<Collider2D>().enabled = false;
            jumpStartTime = Time.time;
            isJumping = true;
        }
        if (Time.time - jumpStartTime > jumpDuration) {
            // End the jump
            usedSprites = new List<Sprite>(baseSprites);
            gameObject.GetComponent<Collider2D>().enabled = true;
            isJumping = false;
        } 
    }

    void OnTriggerStay2D (Collider2D collider) {
        if (collider.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}
