using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARToggle : MonoBehaviour
{
    public void ToggleAR()
    {
        //Check if AR camera is on
        if (VuforiaBehaviour.Instance.enabled)
        {
            //If it's on, turn it off
            VuforiaBehaviour.Instance.enabled = false;
        }
        else
        {
            //If it's off, turn it on
            VuforiaBehaviour.Instance.enabled = true;
        }
    }
}
