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

    Animator animator;

    private static Swiper instance;
    public static Swiper Instance {get {return instance;}}
   // public bool playerChop;

    public SwipeDirecetion Direction { set; get; }
    private Vector3 touchPos;
    private float swipeResX = 1.5f;
    private float swipeResY = 50.0f;
    

    const int state_Walk = 0;
    const int state_Chop = 1;
    private int currentAnimationState = state_Walk;
    AudioSource audioSound;

    private void Start()
    {
        instance = this;
        animator = this.GetComponent<Animator>();
        audioSound = this.GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        Direction = SwipeDirecetion.None;
        StateChange(state_Walk);

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPos - Input.mousePosition;
            if (Mathf.Abs(deltaSwipe.x) > swipeResX)
            {
                //Swipe on the X axis
                Direction |= (deltaSwipe.x < 0) ? SwipeDirecetion.Right : SwipeDirecetion.Left;
            }

            if (Mathf.Abs(deltaSwipe.y) > swipeResY)
            {
                //Swipe on the Y axis
                Direction |= (deltaSwipe.x < 0) ? SwipeDirecetion.Up : SwipeDirecetion.Down;
            }

            if (Mathf.Abs(deltaSwipe.x) <= swipeResX)
            {
                StateChange(state_Chop);

                if (audioSound.isPlaying == true)
                {
                    //Don't play
                }
                else
                {
                    audioSound.Play();
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            touchPos = Input.mousePosition;  
        }

    }

    void StateChange(int state) {

        if (currentAnimationState == state)
            return;

        switch (state)
        {
            case state_Walk:
                animator.SetInteger("state", state_Walk);
                break;

            case state_Chop:
                animator.SetInteger("state", state_Chop);
                break;
        }
                currentAnimationState = state;
        }


    

        public bool IsSwiping(SwipeDirecetion dir)
        {
            return (Direction & dir) == dir;
        }
    }




