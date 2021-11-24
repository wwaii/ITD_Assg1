using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectChanger : MonoBehaviour
{
    //Initialising the Plane Finder game object and Mid Air Positioner game object
    public GameObject planeFinder;
    public GameObject midAirPositioner;

    //Adding all the Ground Plane Stage into a list
    [SerializeField]
    public List<AnchorBehaviour> groundPlaneObjList;

    //Adding all the Mid Air Stage into a list
    [SerializeField]
    public List<AnchorBehaviour> midAirObjList;

    public int currentGroundObj;
    public int currentMidAirObj;

    private void Awake()
    {
        currentGroundObj = 1;
        currentMidAirObj = 1;
    }

    public void ChangeObject()
    {
        //Counting the number of objects in both list
        int i = groundPlaneObjList.Count - 1;
        int j = midAirObjList.Count - 1;

        //Changing the current object to the next object in the list
        planeFinder.GetComponent<ContentPositioningBehaviour>().AnchorStage = groundPlaneObjList[currentGroundObj];
        midAirPositioner.GetComponent<ContentPositioningBehaviour>().AnchorStage = midAirObjList[currentMidAirObj];

        /*Debug.Log(planeFinder.GetComponent<ContentPositioningBehaviour>().AnchorStage);*/
        /*Debug.Log(midAirPositioner.GetComponent<ContentPositioningBehaviour>().AnchorStage);*/

        if (planeFinder.activeInHierarchy)
        {
            if (currentGroundObj == i)
            {
                currentGroundObj = 0;
            }
            else
            {
                currentGroundObj += 1;
            }
        }
        else
        {
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

    public void ChangeStage()
    {
        if (midAirPositioner.activeInHierarchy)
        {
            midAirPositioner.SetActive(false);
            planeFinder.SetActive(true);
        }
        else
        {
            midAirPositioner.SetActive(true);
            planeFinder.SetActive(false);
        }
    }
}
