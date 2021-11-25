using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Boolean to state if the minigame had been cleared
    public static bool isGame1 = false;
    public static bool isGame2 = false;
    public static bool isGame3 = false;

    //Storing the 3D models
    public List<GameObject> virus1;
    public List<GameObject> virus2;
    public List<GameObject> virus3;

    // Update is called once per frame
    void Update()
    {
        //Checking if Game 1 has been cleared
        if (isGame1)
        {
            //If cleared then switch the 3D model
            virus1[0].SetActive(false);
            virus1[1].SetActive(true);
        }

        //Checking if Game 2 has been cleared
        if (isGame2)
        {
            //If cleared then switch the 3D model
            virus2[0].SetActive(false);
            virus2[1].SetActive(true);
        }

        //Checking if Game 3 has been cleared
        if (isGame3)
        {
            //If cleared then switch the 3D model
            virus3[0].SetActive(false);
            virus3[1].SetActive(true);
        }
    }

    public static void CheckGame1()
    {
        //Checking if Game 1 has been cleared
        if (isGame1)
        {
            //If cleared then change to "Image Target" scene
            SceneManager.LoadScene("Image Target");
        }
    }

    public static void CheckGame2()
    {
        //Checking if Game 1 has been cleared
        if (isGame2)
        {
            //If cleared then change to "Image Target" scene
            SceneManager.LoadScene("Image Target");
        }
    }
}
