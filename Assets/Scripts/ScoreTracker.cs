using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {

    protected int score = 0;
    protected UnityEngine.UI.Text text;

    void Awake () {
        text = gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    protected void AddScore (int scoreToAdd) {
        text.text = (int.Parse(text.text) + scoreToAdd).ToString();
    }
}
