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

    public int currentMidAirObj;

    private void Awake()
    {
        // If no game is cleared, spawner will not be active
        if (!GameManager.isGame1 && !GameManager.isGame2 && !GameManager.isGame3)
        {
            midAirPositioner.SetActive(false);
        }

        currentMidAirObj = 1;
    }

    public void ChangeObject()
    {
        //Counting the number of objects in both list
        int j = midAirObjList.Count - 1;


        //This code here should exclude any models that it's game haven't been cleared
        if (!GameManager.isGame1)
        {
            if (currentMidAirObj == 0)
            {
                currentMidAirObj += 1;
            }
        }

        if (!GameManager.isGame2)
        {
            if (currentMidAirObj == 1)
            {
                currentMidAirObj += 1;
            }
        }

        if (!GameManager.isGame3)
        {
            if (currentMidAirObj == 2)
            {
                currentMidAirObj = 0;
            }
        }

        //Changing the current object to the next object in the list
        midAirPositioner.GetComponent<ContentPositioningBehaviour>().AnchorStage = midAirObjList[currentMidAirObj];

        /*Debug.Log(planeFinder.GetComponent<ContentPositioningBehaviour>().AnchorStage);*/
        /*Debug.Log(midAirPositioner.GetComponent<ContentPositioningBehaviour>().AnchorStage);*/

        if (currentMidAirObj == j)
        {
            currentMidAirObj = 0;
        }
        else
        {
            currentMidAirObj += 1;
        }

    }
}
