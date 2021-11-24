using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchTracker : MonoBehaviour
{
    private Touch firstTouch;
    public Vector3 preMouse;

    public Text debugText;

    public int clickCount = 0;

    public GameObject virus1;
    public GameObject virus2;
    public GameObject virus3;

    public float angleX;
    public float angleY;
    public float angleZ;

    private void Update()
    {
        StoreTouches();
    }

    private void StoreTouches()
    {
        //Mouse and Keyboard
        if (Input.GetMouseButtonDown(0))
        {
            /*++clickCount;*/
            /*preText.text = $"Click No.{clickCount - 1} is at: " + preMouse;*/

            //Create variable to store the ray and the RaycastHit information
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;

            //Check if Raycast hit anything
            if (Physics.Raycast(ray, out info))
            {
                //If the ray hit something, display information of what it hit
                //info.collider.name is name of object that the Ray hits
                debugText.text = "First touch is at: " + Input.mousePosition + ". And it hit: " + info.collider.name;
                
                if (info.collider.name == "Virus1")
                {
                    SceneManager.LoadScene("game1");
                    /*angleZ = astronaut.transform.eulerAngles.z;*/
                    /*angleX = astronaut.transform.eulerAngles.x;*/
                    /*angleY = astronaut.transform.eulerAngles.y;*/
/**/
                    /*angleY += 90;*/
                    /*astronaut.transform.eulerAngles = new Vector3(angleX, angleY, angleZ);*/
                }

                if (info.collider.name == "Virus2")
                {
                    SceneManager.LoadScene("game2");
                    /*angleZ = drone.transform.eulerAngles.z;*/
                    /*angleX = drone.transform.eulerAngles.x;*/
                    /*angleY = drone.transform.eulerAngles.y;*/
                    /**/
                    /*angleY += 90;*/
                    /*astronaut.transform.eulerAngles = new Vector3(angleX, angleY, angleZ);*/
                }

                if (info.collider.name == "Virus3")
                {
                    SceneManager.LoadScene("GetVacine");
                    /*angleZ = oxygenTank.transform.eulerAngles.z;*/
                    /*angleX = oxygenTank.transform.eulerAngles.x;*/
                    /*angleY = oxygenTank.transform.eulerAngles.y;*/
                    /**/
                    /*angleY += 90;*/
                    /*astronaut.transform.eulerAngles = new Vector3(angleX, angleY, angleZ);*/
                }
            }
            else
            {
                //If it did not hit anything, display information saying that it didn't
                debugText.text = "First touch is at: " + Input.mousePosition + ". And it didn't hit anything.";
            }
        }

        if (Input.GetMouseButton(0))
        {
            /*debugText.text = $"Click No.{clickCount} is at: " + Input.mousePosition;*/
            /*preMouse = Input.mousePosition;*/
        }

        //Screen
        //Check if there are any touches on the screen.
/*        if (Input.touchCount > 0)
        {
            //If there are touches, store and display their information
            firstTouch = Input.GetTouch(0);

            //Displaying information
            *//*debugText.text = "First touch is at: " + firstTouch.position + ". And is at phase: " + firstTouch.phase;*//*

            //Create variable to store the ray and the RaycastHit information
            Ray ray = Camera.main.ScreenPointToRay(firstTouch.position);
            RaycastHit info;

            //Check if Raycast hit anything
            if (Physics.Raycast(ray,out info))
            {
                //If the ray hit something, display information of what it hit
                //info.collider.name is name of object that the Ray hits
                debugText.text = "First touch is at: " + firstTouch.position + ". And it hit: " + info.collider.name;
            }
            else
            {
                //If it did not hit anything, display information saying that it didn't
                debugText.text = "First touch is at: " + firstTouch.position + ". And it ddin't hit anything.";
            }
        }
        else
        {
            //If there are touches, do nothing
            return;
        }*/
    }
}
