using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Doors : MonoBehaviour
{
    private static string DOOR_OPEN_PARAM_NAME = "isDoorOpen";
    private Animator doorsAnimator;

    public void Start()
    {
        doorsAnimator = GetComponent<Animator>();
    }

    public void setClosed()
    {
        doorsAnimator.SetBool(DOOR_OPEN_PARAM_NAME, false);
    }

    public void setOpen()
    {
        doorsAnimator.SetBool(DOOR_OPEN_PARAM_NAME, true);
    }

    public bool isDoorOpen()
    {
        if (doorsAnimator == null)
        {
            Start();
        }
        return doorsAnimator.GetBool(DOOR_OPEN_PARAM_NAME);
    }
}
