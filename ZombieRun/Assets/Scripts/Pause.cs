using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseButton;
    public GameObject Panel;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        Panel.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        Panel.SetActive(false);
    }

    public void QuitFunc()
    {
        Application.Quit();
    }

}
