using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour {

    public GameObject Tree;
    public Vector3 offset;
    public float spawnTime;
    public float yPosition = 6f;

    //public Vector2 velocity = Vector2.up;
    public int treePosition;
    public int score;
    public float treeSpeed;
    public float treeDeathYValue;
    float timer = 0f;

    public List<GameObject> myTrees;
    public bool stopTrees;
    int currentTreeIndex;

    GameObject playerObj;

    // Use this for initialization
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        spawnTime = Random.Range(1f, 4f);

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime - Time.deltaTime;
        
        if (spawnTime <= 0f)
        {
            TreeSpawning();
            spawnTime = Random.Range(1f, 4f);
        }
        MoveTrees();

        if (Input.GetButtonDown("Jump") && stopTrees)
        {
            DestroyTree();
        }

    }

    public void DestroyTree()
    {

        //store reference to current tree 
        GameObject myCurrentTree = myTrees[currentTreeIndex];
        myTrees.Remove(myCurrentTree); // remove from list
        Destroy(myCurrentTree); //kill the tree
        stopTrees = false; // make them move again

    }

    void TreeSpawning()
    {
        treePosition = Random.Range(1, 3);
        if (treePosition == 1)
        {
            Vector2 position = new Vector2(-2,yPosition);
            myTrees.Add(Instantiate(Tree, position, Quaternion.identity)as GameObject);
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
