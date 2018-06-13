using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public float scoreCounter;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreCounter = scoreCounter + Time.deltaTime;
        scoreText.text = ("Score : " + (int)scoreCounter);
	}
}
