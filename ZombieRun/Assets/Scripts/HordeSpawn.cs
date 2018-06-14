using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSpawn : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;
    public Vector3 offset;
    public float spawnTime = 2f;
    public float minX = -10f;
    public float maxX = 10;
    public float yPosition = -6f;

    //public Vector2 velocity = Vector2.up;

    public int score;

    float timer = 0f;

    // Use this for initialization
    void Start()
    {
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
            ZombieSelector();
            timer = spawnTime;
            
        }

    }

   void ZombieSelector ()
    {
        int enemySelect = Random.Range(1, 4);
        if (enemySelect == 1)
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), yPosition);
            Instantiate(enemy, position, Quaternion.identity);
        }
        if (enemySelect == 2)
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), yPosition);
            Instantiate(enemy1, position, Quaternion.identity);
        }
        if (enemySelect == 3)
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), yPosition);
            Instantiate(enemy2, position, Quaternion.identity);
        }
    }

}
