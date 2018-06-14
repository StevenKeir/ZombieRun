using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public GameObject playerIcon;
    public GameOver gameOverScript;

    [Range(-1, 1)]
    public int posInt = 0;
    



    // Update is called once per frame
    void Update () {


        if (Swiper.Instance.IsSwiping(SwipeDirecetion.Left))
        {
            if(posInt > -1)
            {
                posInt--;
            }
        
        }
        if (Swiper.Instance.IsSwiping(SwipeDirecetion.Right))
        {
            if(posInt < 1)
            {
                posInt++;
            }
      
        }

        switch (posInt)
        {
            case -1:
                playerIcon.transform.position = new Vector3(-2, 0, 0);
                break;
            case 0:
                playerIcon.transform.position = new Vector3(0, 0, 0);
                break;
            case 1:
                playerIcon.transform.position = new Vector3(2, 0, 0);
                break;
        }

   

	}

    // Destroy the player when it collides with an enemy.
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("collisons with"+other.gameObject.name);

        if (other.gameObject.layer == LayerMask.NameToLayer("Zombie"))
        {
            // Debug.Log("collison with zombi layer");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameOverScript.GameOverScreen();
        }
    }


}
