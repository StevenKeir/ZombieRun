using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverBG;
    public Text scoreItem;

    Score scoreScript;
    

	void Start () {
        	
	}
	
	
	public void GameOverScreen () {

        Time.timeScale = 0;
        gameOverBG.SetActive(true);


	}

    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

}
