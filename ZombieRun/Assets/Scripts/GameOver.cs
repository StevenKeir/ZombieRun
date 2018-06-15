using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour {

    public GameObject gameOverBG;
    public GameObject pauseButton;
    public Text scoreItem;
   
    public Score scoreScript;
    

	
	public void GameOverScreen () {

        Time.timeScale = 0;
        gameOverBG.SetActive(true);
        pauseButton.SetActive(false);
        scoreItem.text = ("Final Score: " + (int) scoreScript.scoreCounter);
            

	}

    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        pauseButton.SetActive(true);
    }

}
