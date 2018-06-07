using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirecetion
{
    None = 0,
    Left = 1,
    Right = 2,
    Up = 4,
    Down = 8,
}

public class Swiper : MonoBehaviour {

    private static Swiper instance;
    public static Swiper Instance {get {return instance;}}



    public SwipeDirecetion Direction { set; get; }
    private Vector3 touchPos;
    private float swipeResX = 5.0f;
    private float swipeResY = 50.0f;


    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        Direction = SwipeDirecetion.None;

        if (Input.GetMouseButton(0))
        {
            touchPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPos - Input.mousePosition;

            if(Mathf.Abs(deltaSwipe.x) > swipeResX)
            {
                //Swipe on the X axis
                Direction |= (deltaSwipe.x < 0) ? SwipeDirecetion.Right : SwipeDirecetion.Left;
            }

            if (Mathf.Abs(deltaSwipe.y) > swipeResY)
            {
                //Swipe on the Y axis
                Direction |= (deltaSwipe.x < 0) ? SwipeDirecetion.Up : SwipeDirecetion.Down;
            }
        }
    }

   
        public bool IsSwiping(SwipeDirecetion dir)
        {
            return (Direction & dir) == dir;
        }
    }




