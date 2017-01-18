using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour {

    public float speed = 0.5f;
    public float frameDelay = 0.3f;
    public List<Sprite> baseSprites;
    
    protected float lastFrameTime = 0f;
    protected int frameCounter = 0;
    protected Vector3 tempScale;
    protected List<Sprite> usedSprites = new List<Sprite>();   

	void Update () {
        Animate();
        Move();
        CheckOOB();
    }

    public virtual void Move () {
        UpdatePosition(transform.position+Vector3.down*speed*Time.deltaTime);
    }

    public virtual void Animate () {
        // Sprite lists can't be empty. Gotta be animating something
        if (usedSprites.Count == 0) {
            usedSprites = new List<Sprite> (baseSprites);
        }
        int numSprites = usedSprites.Count;
        if ((numSprites > 0) & (Time.time - lastFrameTime >= frameDelay)) {
            frameCounter = (frameCounter+1) % numSprites;
            GetComponent<SpriteRenderer>().sprite = usedSprites[frameCounter];
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

    protected void UpdatePosition (Vector3 newPos) {
        // Things closer to the bottom should be on top, visually
        // Linear interpolation assumes screen from 5 to -5
        // newPos.z = 0.5f * (newPos.y-5f)/10f + actualLayerOrWhatever;
        // Needs an actual base layer or whatever

        Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
        if (rigidbody != null) {
            ///rigidbody.MovePosition(new Vector2 (newPos.x, newPos.y)); ??
            rigidbody.MovePosition(newPos);
        } else {
            transform.position = newPos;
        }
    }
}
