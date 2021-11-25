using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchTracker : MonoBehaviour
{
    private Touch firstTouch;

    public GameObject virus1;
    public GameObject virus2;
    public GameObject virus3;

    public GameObject virus1Button;
    public GameObject virus2Button;
    public GameObject virus3Button;

    private void Update()
    {
        //Check if there is a mouse click or a touch input
        StoreTouches();
    }

    private void StoreTouches()
    {
        //Checking if there is a left click of the mouse
        if (Input.GetMouseButtonDown(0))
        {
            //If there is a left click, then assign the following variables
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;

            //Check if Raycast hit anything
            if (Physics.Raycast(ray, out info))
            {
                //Checking if the name of the object is Virus1
                if (info.collider.name == "Virus1")
                {
                    //If the name is Virus1, activate the button that will start the minigame
                    virus1Button.SetActive(true);
                }

                //Checking if the name of the object is Virus2
                if (info.collider.name == "Virus2")
                {
                    //If the name is Virus2, activate the button that will start the minigame
                    virus2Button.SetActive(true);
                }

                //Checking if the name of the object is Virus3
                if (info.collider.name == "Virus3")
                {
                    //If the name is Virus3, activate the button that will start the minigame
                    virus3Button.SetActive(true);
                }
            }
        }

        //Checking if there is a touch input
        if (Input.touchCount > 0)
        {
            //If there is a touch input, then assign the following variables
            firstTouch = Input.GetTouch(0);
            Ray touchRay = Camera.main.ScreenPointToRay(firstTouch.position);
            RaycastHit touchInfo;

            //Check if Raycast hit anything
            if (Physics.Raycast(touchRay, out touchInfo))
            {
                //Checking if the name of the object is Virus1
                if (touchInfo.collider.name == "Virus1")
                {
                    //If the name is Virus1, activate the button that will start the minigame
                    SceneManager.LoadScene("game1");
                }

                //Checking if the name of the object is Virus2
                if (touchInfo.collider.name == "Virus2")
                {
                    //If the name is Virus2, activate the button that will start the minigame
                    SceneManager.LoadScene("game2");
                }

                //Checking if the name of the object is Virus3
                if (touchInfo.collider.name == "Virus3")
                {
                    //If the name is Virus3, activate the button that will start the minigame
                    SceneManager.LoadScene("GetVacine");
                }
            }
        }
    }

    //Scene Changer
    public void LoadGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
