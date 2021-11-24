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
    public GameObject winText;
    public GameObject endGameButton;
    private Touch firstTouch;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < 0)
            {
                rot = rotateAmount;
            }
            else
            {
                rot = -rotateAmount;
            }

            transform.Rotate(0, 0, rot);
        }

        if (Input.touchCount > 0)
        {
            firstTouch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(firstTouch.position);

            if (touchPos.x < 0)
            {
                rot = rotateAmount;
            }
            else
            {
                rot = -rotateAmount;
            }

            transform.Rotate(0, 0, rot);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Vacine")
        {
            Destroy(collision.gameObject);
            score++;

            if (score >= 5)
            {
                Time.timeScale = 0;
                winText.SetActive(true);
                endGameButton.SetActive(true);
                GameManager.isGame3 = true;
            }
        }
        else if (collision.gameObject.tag == "Virus")
        {
            SceneManager.LoadScene("GetVacine");
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("");
    }
}
