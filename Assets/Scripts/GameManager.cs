using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGame1 = false;
    public static bool isGame2 = false;
    public static bool isGame3 = false;

    public List<GameObject> virus1;
    public List<GameObject> virus2;
    public List<GameObject> virus3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGame1)
        {
            virus1[0].SetActive(false);
            virus1[1].SetActive(true);
        }

        if (isGame2)
        {
            virus2[0].SetActive(false);
            virus2[1].SetActive(true);
        }

        if (isGame3)
        {
            virus3[0].SetActive(false);
            virus3[1].SetActive(true);
        }
    }

    public static void CheckGame1()
    {
        if (isGame1)
        {
            SceneManager.LoadScene("Image Target");
        }
    }

    public static void CheckGame2()
    {
        if (isGame2)
        {
            SceneManager.LoadScene("Image Target");
        }
    }
}
