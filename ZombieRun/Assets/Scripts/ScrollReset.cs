using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollReset : MonoBehaviour
{

    public GameObject background2;
    Vector2 startPos;
    Vector2 b2Transform;
    public float backgroundSpeed = 1f;
    void Start()
    {
        startPos = background2.transform.position;
    }

    void Update()
    {
        b2Transform = background2.transform.position;
        ScrollDown();

        if (b2Transform.y <= 0)
        {
            BGReset();
        }
    }
    void BGReset()
    {
        background2.transform.position = startPos;
        transform.position = startPos - startPos;
    }
    void ScrollDown()
    {
        transform.Translate(Vector3.down *backgroundSpeed * Time.deltaTime);
        background2.transform.Translate(Vector3.down *backgroundSpeed * Time.deltaTime);
    }
}
