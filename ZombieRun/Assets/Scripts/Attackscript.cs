using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackscript : MonoBehaviour {

    GameObject spawnerObj;
    GameObject backGround;
    ScrollReset resetScript;
    TreeSpawn treeScript;
    Swiper swipeScript;

	void Start () {

        spawnerObj = GameObject.Find("Spawner");
        backGround = GameObject.Find("BackGround1");
        resetScript = backGround.GetComponent<ScrollReset>();
        treeScript = spawnerObj.GetComponent<TreeSpawn>();
        swipeScript = spawnerObj.GetComponent<Swiper>();

	}
	
	void Update () {

        if (swipeScript.playerChop == true && treeScript.stopTrees == true)
        {
            treeScript.DestroyTree();
        }

    }
}
