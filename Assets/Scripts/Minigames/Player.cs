using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    float rot;
    int score;
    public GameObject endGame;
    private Touch firstTouch;

    private void Awake()
    {
        //Retriving the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Start()
    {
        //Pausing the game so that the player can read the instructions
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if there is a left click of the mouse
        if (Input.GetMouseButton(0))
        {
            //If there is a left click, then assign the following variables
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //If the mouse position on the x-axis is negative (on the left)
            if (mousePos.x < 0)
            {
                //Rotate left
                rot = rotateAmount;
            }
            else //If the mouse position on the x-axis is not negative (on the right)
            {
                //Rotate right
                rot = -rotateAmount;
            }

            //Rotation
            transform.Rotate(0, 0, rot);
        }

        //Checking if there is a touch input
        if (Input.touchCount > 0)
        {
            //If there is a touch input, then assign the following variables
            firstTouch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(firstTouch.position);


            //If the touch position on the x-axis is negative (on the left)
            if (touchPos.x < 0)
            {
                //Rotate left
                rot = rotateAmount;
            }
            else //If the touch position on the x-axis is not negative (on the right)
            {
                //Rotate right
                rot = -rotateAmount;
            }

            //Rotation
            transform.Rotate(0, 0, rot);
        }
    }

    private void FixedUpdate()
    {
        //Moving the player forward
        rb.velocity = transform.up * moveSpeed;
    }

    //If collided
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checking if the tag of the object collided is "Vacine"
        if (collision.gameObject.tag == "Vacine")
        {
            //If the name of the object is "Vacine", then...
            Destroy(collision.gameObject);
            score++;

            //If score is equal or more than 5
            if (score >= 5)
            {
                //Pause the game
                Time.timeScale = 0;

                //Activate the Game Clear Menu
                endGame.SetActive(true);

                //Game 3 is cleared
                GameManager.isGame3 = true;
            }
        }
        else if (collision.gameObject.tag == "Virus") //Checking if the tag of the object collided is "Virus"
        {
            //If the tag of the object collided is "Virus", then restart game by reloading the scene
            SceneManager.LoadScene("GetVacine");
        }
    }

    //Returning to menu
    public void EndGame()
    {
        //Unpausing the game
        Time.timeScale = 1;

        //Load "Image Target" scene
        SceneManager.LoadScene("Image Target");
    }

    //Pause game
    public void PauseGame()
    {
        //Stop time
        Time.timeScale = 0;
    }

    //Resume game
    public void ResumeGame()
    {
        //Resume time
        Time.timeScale = 1;
    }

}
