using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    GameObject newPlayer;
    Swiper mySwiperScript;
    public Vector2 velocity = Vector2.down;
    TreeSpawn myTreeSpawnScript;
    private Vector2 targetPos;
    GameObject spawner;
    

    int treeHealth;

	// Use this for initialization
	void Start () {
        newPlayer = GameObject.FindGameObjectWithTag("Player");
        mySwiperScript = newPlayer.GetComponent<Swiper>();
        spawner = GameObject.Find("Spawner");
        myTreeSpawnScript = spawner.GetComponent<TreeSpawn>();
        treeHealth = Random.Range(3, 6);
       
    }
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector2(myTreeSpawnScript.treePosition,0);
        transform.position = transform.position + Vector3.down * Time.deltaTime;// Vector2.MoveTowards(transform.position,targetPos,0.05f);

        if(transform.position.y <= 0)
        {

            Destroy(gameObject);
        }
    }

    void TreeProperties ()
    {
            if (treeHealth <= 0)
            {
            Debug.Log("Tree Falls");
             }

        else {
            Debug.Log("Tree Standing");
             }
    }

    // Destroy the player when it collides with an enemy.
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("collisons with"+other.gameObject.name);

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("pause Scene");

                if (mySwiperScript.playerChop == true)
            {
                treeHealth = treeHealth - 1;
            }
        }
    }

}
