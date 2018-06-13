using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeFollowPlayer : MonoBehaviour{

    private GameObject player;
    public float speed = 0.08f;
    public Score myScoreScript;

    void Start()
    {
        speed = 0.08f;
        player = GameObject.FindGameObjectWithTag("Player");
        myScoreScript = ;
    }

    // Update is called once per frame
    void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position,step);
    }

  
    void SpeedIncrease ()
    {
        if (myScoreScript.scoreCounter > 40)
        {
            speed = 0.2f;
        }
        else if (myScoreScript.scoreCounter > 30)
        {
            speed = 0.18f;
        }
        else if (myScoreScript.scoreCounter > 20)
        {
            speed = 0.14f;
        }
        else if (myScoreScript.scoreCounter > 10)
        {
            speed = 0.1f;
        }
        else speed = 0.08f;
    }
   
}
