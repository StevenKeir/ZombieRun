﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour {

    public GameObject Tree;
    GameObject backGround;
    ScrollReset resetScript;
    public Vector3 offset;
    public float spawnTime;
    public float yPosition = 6f;
    public Sprite normalTree;
    public Sprite fallenTree1;

    private SpriteRenderer sRender;
    //public Vector2 velocity = Vector2.up;
    public int treePosition;
    public float treeSpeed;
    public float treeDeathYValue;
    float timer = 0f;

    public List<GameObject> myTrees;
    public bool stopTrees;
    public bool fallenTree;
    int currentTreeIndex;
    int treeHealth;

    GameObject playerObj;
    Swiper swiperScript;
    GameObject canvas;
    Score scoreScript;

    // Use this for initialization
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        swiperScript = playerObj.GetComponent<Swiper>();
        backGround = GameObject.Find("BackGround1");
        resetScript = backGround.GetComponent<ScrollReset>();
        canvas = GameObject.Find("Canvas");
        scoreScript = canvas.GetComponent<Score>();
        spawnTime = Random.Range(0.5f, 3f);
        treeHealth = Random.Range(4, 7);

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime - Time.deltaTime;
        
        if (spawnTime <= 0f)
        {
            TreeSpawning();
            spawnTime = Random.Range(0.25f, 2.75f);
            treeHealth = Random.Range(3, 5);
        }
        MoveTrees();

        if (swiperScript.playerChop == true)
        {
            treeHealth = treeHealth - 1;
        }

        if (stopTrees && treeHealth <= 0)
        {
            DestroyTree();
        }

    }
    
    public void DestroyTree()
    {
        //store reference to current tree 
        GameObject myCurrentTree = myTrees[currentTreeIndex];
        myTrees[currentTreeIndex].layer = 10;
        //myTrees.Remove(myCurrentTree); // remove from list
        // Destroy(myCurrentTree); //kill the tree
        stopTrees = false; // make them move again
        resetScript.backgroundSpeed = 1;
        scoreScript.time = true;
    }

    void TreeSpawning()
    {
        if (!stopTrees)
        {
            treePosition = Random.Range(1, 6);
            if (treePosition == 1)
            {
                Vector2 position = new Vector2(-2, yPosition);
                myTrees.Add(Instantiate(Tree, position, Quaternion.identity) as GameObject);
            }
            if (treePosition == 2)
            {
                Vector2 position = new Vector2(0, yPosition);
                myTrees.Add(Instantiate(Tree, position, Quaternion.identity) as GameObject);
            }
            if (treePosition == 3)
            {
                Vector2 position = new Vector2(2, yPosition);
                myTrees.Add(Instantiate(Tree, position, Quaternion.identity) as GameObject);
            }
            if (treePosition == 4)
            {
                Vector2 position = new Vector2(4, yPosition);
                myTrees.Add(Instantiate(Tree, position, Quaternion.identity) as GameObject);
            }
            if (treePosition == 5)
            {
                Vector2 position = new Vector2(-4, yPosition);
                myTrees.Add(Instantiate(Tree, position, Quaternion.identity) as GameObject);
            }
        }
    }
    
   void MoveTrees()
    {
        
        //do nothing if the trees have stopped
        if (!stopTrees)
        {
            for (int i = 0; i < myTrees.Count; i++)
            {
               
                //store the reference to the current tree we are looking at
                GameObject myCurrentTree = myTrees[i];
                //move the tree
                myCurrentTree.transform.position = myTrees[i].transform.position + Vector3.down * treeSpeed * Time.deltaTime;

                //checks the distance between the tree and the player and stops the trees if you are close enough
                if((myCurrentTree.transform.position - playerObj.transform.position).magnitude < 0.25f && myCurrentTree.transform.position.y > playerObj.transform.position.y)
                {
                    stopTrees = true;
                    resetScript.backgroundSpeed = 0;
                    scoreScript.time = false;
                    //stores which tree stopped you.
                    currentTreeIndex = i;
                }
              
                //kills tree when below the camera
                if (myCurrentTree.transform.position.y <= treeDeathYValue)
                {
                    myTrees.Remove(myCurrentTree);
                    Destroy(myCurrentTree);                
                }

            }

        }
    }


}
