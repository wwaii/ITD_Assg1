using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracker : MonoBehaviour
{
    private Dictionary<GameObject, bool> trackedObjectStatus = new Dictionary<GameObject, bool>();

    public Text debugText;

    public void ObjectTracked(GameObject objectToTrack)
    {
        //Check if the passed in object is null
        if (objectToTrack != null)
        {
            //If it's not null, update the dictionary
            trackedObjectStatus[objectToTrack] = true;
        }
        else
        {
            //If it's null,do nothing
            return;
        }
    }
    public void ObjectLost(GameObject objectToTrack)
    {
        //Check if the passed in object is null
        if (objectToTrack != null)
        {
            //If it's not null, update the dictionary
            trackedObjectStatus[objectToTrack] = false;
        }
        else
        {
            //If it's null,do nothing
            return;
        }
    }

    public void UpdateText()
    {
        //Reset the UI text to blank
        debugText.text = "";

        //Iterate through the dictionary and display that status of each object
        foreach(KeyValuePair<GameObject, bool> objectStatus in trackedObjectStatus)
        {
            debugText.text += objectStatus.Key.name + ": " + objectStatus.Value + '\n';
        }
    }

    private void Update()
    {
        UpdateText();
    }
}
