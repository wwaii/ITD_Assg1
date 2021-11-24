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

    public string prizeValue;

    public Text winText;

    private bool resultsChecked = false;

    private bool doAgain = false;

    private bool gameClear;

    private void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = "";
            resultsChecked = false;
        }

        if (!rows[0].rowStopped && !rows[1].rowStopped && !rows[2].rowStopped && !resultsChecked)
        {
            CheckResults();
        }

        winText.text = prizeValue;

        if (gameClear)
        {
            GameManager.isGame2 = true;
            GameManager.CheckGame2();
        }
    }

    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
            StartCoroutine("PullHandle");
    }

    private IEnumerator PullHandle()
    {
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }

        HandlePulled();

        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CheckResults()
    {
        // If JackPod, Game is cleared
        if (rows[0].stoppedSlot == "Diamond" && rows[1].stoppedSlot == "Diamond" && rows[2].stoppedSlot == "Diamond")
        {
            prizeValue = "Game Clear";
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Crown" && rows[1].stoppedSlot == "Crown" && rows[2].stoppedSlot == "Crown")
        {
            prizeValue = "Game Clear";
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Melon" && rows[1].stoppedSlot == "Melon" && rows[2].stoppedSlot == "Melon")
        {
            prizeValue = "Game Clear";
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Bar" && rows[1].stoppedSlot == "Bar" && rows[2].stoppedSlot == "Bar")
        {
            prizeValue = "Game Clear";
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Seven" && rows[1].stoppedSlot == "Seven" && rows[2].stoppedSlot == "Seven")
        {
            prizeValue = "Game Clear";
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Cherry" && rows[1].stoppedSlot == "Cherry" && rows[2].stoppedSlot == "Cherry")
        {
            prizeValue = "Game Clear";
            gameClear = true;
        }
        else if (rows[0].stoppedSlot == "Lemon" && rows[1].stoppedSlot == "Lemon" && rows[2].stoppedSlot == "Lemon")
        {
            prizeValue = "Game Clear";
            gameClear = true;
        }

        resultsChecked = true;
    }
}

