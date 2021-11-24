using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautController : MonoBehaviour
{
    public Animator myAnimator;
    
    public void StartWave()
    {
        //Set the "IsWaving" bool in myAnimator to true
        myAnimator.SetBool("IsWaving", true);
    }
}
