using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    //Scene Changer
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
