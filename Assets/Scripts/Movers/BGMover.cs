using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : UnitControl {

    protected bool spriteChosen = false;

	public override void Animate () {
        if (!spriteChosen) {
            // Apply a random sprite from the provided list
    		transform.GetComponent<SpriteRenderer>().sprite = baseSprites[Random.Range (0, baseSprites.Count-1)];
            spriteChosen = true;
        }
    }
}
