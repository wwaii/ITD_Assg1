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

    public int prizeValue;

    private bool resultsChecked = false;

    private bool doAgain = false;

    private void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            resultsChecked = false;
        }

        if (!rows[0].rowStopped && !rows[1].rowStopped && !rows[2].rowStopped && !resultsChecked)
        {
            CheckResults();
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
        Debug.Log("test");
        if (rows[0].stoppedSlot == "Diamond"
            && rows[1].stoppedSlot == "Diamond"
            && rows[2].stoppedSlot == "Diamond")

            prizeValue = 200;

        else if (rows[0].stoppedSlot == "Crown"
            && rows[1].stoppedSlot == "Crown"
            && rows[2].stoppedSlot == "Crown")

            prizeValue = 400;

        else if (rows[0].stoppedSlot == "Melon"
            && rows[1].stoppedSlot == "Melon"
            && rows[2].stoppedSlot == "Melon")

            prizeValue = 600;

        else if (rows[0].stoppedSlot == "Bar"
            && rows[1].stoppedSlot == "Bar"
            && rows[2].stoppedSlot == "Bar")

            prizeValue = 800;

        else
            prizeValue = 10;

        resultsChecked = true;
    }
}
