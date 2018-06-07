using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeFollowPlayer : MonoBehaviour{

    public Transform player;
    public float speed = 1.0f;
    

	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,player.position,step);
    }
}
