using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeFollowPlayer : MonoBehaviour{

    private GameObject player;
    public float speed = 0.08f;
    public Score myScoreScript;
    public Rigidbody2D rb;
    public TreeSpawn tree;
    

    void Start()
    {
        
        speed = 0.08f;
        player = GameObject.FindGameObjectWithTag("Player");
        myScoreScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

        float step;
        step = speed * Time.deltaTime; 

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        SpeedIncrease();
    }

  
    void SpeedIncrease ()
    { 
            if (myScoreScript.scoreCounter > 100)
            {
                speed = 0.46f;
            }
            else if (myScoreScript.scoreCounter > 90)
            {
                speed = 0.42f;
            }
            else if (myScoreScript.scoreCounter > 80)
            {
                speed = 0.38f;
            }
            else if (myScoreScript.scoreCounter > 70)
            {
                speed = 0.34f;
            }
            else if (myScoreScript.scoreCounter > 60)
            {
                speed = 0.3f;
            }
            else if (myScoreScript.scoreCounter > 50)
            {
                speed = 0.26f;
            }
            else if (myScoreScript.scoreCounter > 40)
            {
                speed = 0.22f;
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

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("FallenTree"))
        {
            //  Debug.Log("HelpME");
            transform.position = new Vector2(transform.position.x,-5);
            
        }
    }


}
