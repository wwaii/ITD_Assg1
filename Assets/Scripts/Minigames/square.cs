using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    public Transform squarePlace;

    private Vector2 initialPosition;

    private float dX, dY;

    public GameObject afterGame;

    public static bool locked;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if there is a touch input and the object is not in place
        if (Input.touchCount > 0 && !locked)
        {
            //If there is a touch input and the object is not in place, then assign the following variables
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            //Moving the objects using touch
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
                    if (Mathf.Abs(transform.position.x - squarePlace.position.x) <= 30f && (Mathf.Abs(transform.position.y - squarePlace.position.y) <= 30f))
                    {
                        transform.position = new Vector2(squarePlace.position.x, squarePlace.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
            }
        }

        if (locked && circle.locked && diamond.locked)
        {
            //Game 2 is cleared
            GameManager.isGame1 = true;

            //Activate the Game Clear Menu
            afterGame.SetActive(true);
        }
    }
}
