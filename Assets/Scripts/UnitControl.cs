using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour {

    public float speed = 1f;
    public float frameDelay = 0.3f;
    public Sprite[] baseSprites;
    
    protected float lastFrameTime = 0f;
    protected int frameCounter = 0;
    protected Vector3 tempScale;
	
	// Update is called once per frame
	void Update () {
        Animate();
        Move();
        CheckOOB();
    }

    public virtual void Move () {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public virtual void Animate () {
        if (Time.time - lastFrameTime >= frameDelay) {
            frameCounter = (frameCounter+1) % baseSprites.Length;
            GetComponent<SpriteRenderer>().sprite = baseSprites[frameCounter];
            lastFrameTime = Time.time;    
        }
    }

    protected void CheckOOB () {
        if (transform.position.magnitude > 5) {
            Destroy(gameObject);
        }
    }

    protected void FlipSprite (Vector3 move) {
        // Mirror sprites, hitboxes, etc, if moving to the right
        tempScale = transform.localScale;
        if (move.x > 0) {
            tempScale.x = -Mathf.Abs(tempScale.x);
        } else {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        transform.localScale = tempScale;
    }
}
