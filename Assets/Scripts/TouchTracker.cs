using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchTracker : MonoBehaviour
{
    private Touch firstTouch;
    public Vector3 preMouse;

    public int clickCount = 0;

    public GameObject virus1;
    public GameObject virus2;
    public GameObject virus3;

    public GameObject virus1Button;
    public GameObject virus2Button;
    public GameObject virus3Button;

    public float dX;
    public float dY;
    public float dZ;

    private void Update()
    {
        StoreTouches();
    }

    private void StoreTouches()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if (Physics.Raycast(ray, out info))
            {
                Debug.Log(info.collider.name);
                
                if (info.collider.name == "Virus1")
                {
                    virus1Button.SetActive(true);
                }

                if (info.collider.name == "Virus2")
                {
                    virus2Button.SetActive(true);
                }

                if (info.collider.name == "Virus3")
                {
                   virus3Button.SetActive(true);
                }
            }
        }

        //Touch
        if (Input.touchCount > 0)
        {
            firstTouch = Input.GetTouch(0);
            Ray touchRay = Camera.main.ScreenPointToRay(firstTouch.position);
            RaycastHit touchInfo;

            //Check if Raycast hit anything
            if (Physics.Raycast(touchRay, out touchInfo))
            {
                if (touchInfo.collider.name == "Virus1")
                {
                    SceneManager.LoadScene("game1");
                }

                if (touchInfo.collider.name == "Virus2")
                {
                    SceneManager.LoadScene("game2");
                }

                if (touchInfo.collider.name == "Virus3")
                {
                    SceneManager.LoadScene("GetVacine");
                }
            }
        }
    }


    public void LoadGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
