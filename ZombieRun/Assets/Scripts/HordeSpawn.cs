using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSpawn : MonoBehaviour {

    public GameObject enemy;
    Rigidbody2D OurRigidbody;
    public Vector3 offset;
    public float spawnTime = 2f;
    public float minX = -500f;
    public float maxX = 500f;
    public float yPosition = -400f;

    //public Vector2 velocity = Vector2.up;

    public int score;

    float timer = 0f;

    // Use this for initialization
    void Start()
    {
        OurRigidbody = GetComponent<Rigidbody2D>();
      //  OurRigidbody.velocity = velocity;
        timer = spawnTime;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
  
        timer = timer - Time.deltaTime;
        
        // Every two seconds
        if (timer <= 0f)
        {
            // Spawn an enemy at a random location.
            Vector2 position = new Vector2(yPosition, Random.Range(minX, maxX));
            Instantiate(enemy, position, Quaternion.identity);
            timer = spawnTime;
            
 /*           if (score >= 10)
            {
               OurRigidbody.velocity = new Vector2(0,1.1);
               spawnTime = 1.8f;
            }*/
        }

    }

}
