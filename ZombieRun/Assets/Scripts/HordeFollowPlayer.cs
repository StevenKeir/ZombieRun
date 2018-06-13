﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeFollowPlayer : MonoBehaviour{

    public Transform player;
    public float speed = 0.08f;
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,player.position,step);
    }

    /*
    void SpeedIncrease ()
    {
        if (score > 40)
        {
            speed = 0.2f;
        }
        if (score > 30)
        {
            speed = 0.18f;
        }
        if (score > 20)
        {
            speed = 0.14f;
        }
        if (score > 10)
        {
            speed = 0.1f;
        }
        else speed = 0.08f;
    }
    */
}
