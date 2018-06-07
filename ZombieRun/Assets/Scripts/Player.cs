using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject playerIcon;

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
}
