using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectChanger : MonoBehaviour
{
    //Initialising the Plane Finder game object and Mid Air Positioner game object
    public GameObject midAirPositioner;

    //Adding all the Mid Air Stage into a list
    [SerializeField]
    public List<AnchorBehaviour> midAirObjList;

    public int MidAirObj;

    public GameObject objectChanger;

    public GameObject noGameText;

    private void Awake()
    {
        CheckGame();
        MidAirObj = 0;
    }

    private void Update()
    {
        CheckObject();
    }

    public void ChangeObject()
    {
        //Counting the number of objects in both list
        int j = midAirObjList.Count - 1;

        //Calling the CheckObject() Function
        CheckObject();

        //Resetting the value of MidAirObj to prevent error
        if (MidAirObj == j)
        {
            MidAirObj = 0;
        }
        else
        {
            MidAirObj += 1;
        }

    }

    public void CheckGame()
    {
        //If no game is cleared, the spawner will be turned off
        if (!GameManager.isGame1 && !GameManager.isGame2 && !GameManager.isGame3)
        {
            //Turning off the Spawner and Change Object button
            midAirPositioner.SetActive(false);
            objectChanger.SetActive(false);
            noGameText.SetActive(true);
        }
        else
        {
            noGameText.SetActive(false);
            objectChanger.SetActive(true);
        }
    }

    public void CheckObject()
    {
        //This code here should exclude any models that it's game haven't been cleared
        if (!GameManager.isGame1)
        {
            if (MidAirObj == 0)
            {
                MidAirObj += 1;
            }
        }

        if (!GameManager.isGame2)
        {
            if (MidAirObj == 1)
            {
                MidAirObj += 1;
            }
        }

        if (!GameManager.isGame3)
        {
            if (MidAirObj == 2)
            {
                MidAirObj = 0;
            }
        }

        //Changing the current object to the next object in the list
        midAirPositioner.GetComponent<ContentPositioningBehaviour>().AnchorStage = midAirObjList[MidAirObj];
    }
}
