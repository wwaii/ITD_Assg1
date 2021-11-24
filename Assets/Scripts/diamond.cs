using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamond : MonoBehaviour
{
    public Transform diamondPlace;

    private Vector2 initialPosition;

    private float dX, dY;

    public static bool locked;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        dX = touchPos.x - transform.position.x;
                        dY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - dX, touchPos.y - dY);
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - diamondPlace.position.x) <= 30f && (Mathf.Abs(transform.position.y - diamondPlace.position.y) <= 30f))
                    {
                        transform.position = new Vector2(diamondPlace.position.x, diamondPlace.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
            }
        }
    }
}
