using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SlotMachineController : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    public Row[] rows;

    public Transform handle;

    public bool resultsChecked = false;

    public bool gameClear = false;

    public GameObject afterGame;

    private void Update()
    {
        //If the roll has stopped and results has already been checked
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            //Resetting resultsChecked
            resultsChecked = false;
        }

        //If the roll has stopped and the results still have not been checked
        if (!rows[0].rowStopped && !rows[1].rowStopped && !rows[2].rowStopped && !resultsChecked)
        {
            //Calling CheckResults function
            CheckResults();
        }

        //Checking if the game is cleared
        if (gameClear)
        {
            //If the game has been cleared

            //Game 2 is cleared
            GameManager.isGame2 = true;

            //Activate the Game Clear Menu
            afterGame.SetActive(true);
        }
    }

    //If there is a mouse click
    private void OnMouseDown()
    {
        //If the roll has stopped
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            //Start "PullHandle"
            StartCoroutine("PullHandle");
        }
    }

    private IEnumerator PullHandle()
    {
        //Rotating the handle away
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }

        //Handle is pulled
        HandlePulled();

        //Rotating the handle back
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CheckResults()
    {
        //If JackPod, game 3 is cleared
        if (rows[0].stoppedSlot == "Diamond" && rows[1].stoppedSlot == "Diamond" && rows[2].stoppedSlot == "Diamond")
        {
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Crown" && rows[1].stoppedSlot == "Crown" && rows[2].stoppedSlot == "Crown")
        {
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Melon" && rows[1].stoppedSlot == "Melon" && rows[2].stoppedSlot == "Melon")
        {
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Bar" && rows[1].stoppedSlot == "Bar" && rows[2].stoppedSlot == "Bar")
        {
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Seven" && rows[1].stoppedSlot == "Seven" && rows[2].stoppedSlot == "Seven")
        {
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Cherry" && rows[1].stoppedSlot == "Cherry" && rows[2].stoppedSlot == "Cherry")
        {
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Lemon" && rows[1].stoppedSlot == "Lemon" && rows[2].stoppedSlot == "Lemon")
        {
            gameClear = true;
        }

        //Results has been checked
        resultsChecked = true;
    }
}

