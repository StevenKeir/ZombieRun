using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public float scoreCounter;
    public Text scoreText;
    public bool time;

	// Use this for initialization
	void Start () {
        scoreCounter = 0;
        time = true;
	}
	
	// Update is called once per frame
	void Update () {
        TimeStart();
	}

    void TimeStart()
    {
        if (time == true)
        {
            scoreCounter = scoreCounter + Time.deltaTime;
            scoreText.text = ("Score : " + (int)scoreCounter);
        }
        else
        {
            scoreText.text = ("Score : " + (int)scoreCounter);
        }
    }
}
