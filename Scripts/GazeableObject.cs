using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableObject : MonoBehaviour
{
    public virtual void OnGazeEnter(RaycastHit hitInfo)
    {
        Debug.Log("Gaze entered on " + gameObject.name);
    }

    public virtual void OnGaze(RaycastHit hitInfo)
    {
        Debug.Log("Gaze hold on " + gameObject.name);
    }

    public virtual void OnGazeExit()
    {
        Debug.Log("Gaze exited on " + gameObject.name);
    }

    // mouse status press, hold, release 
    public virtual void OnPress(RaycastHit hitInfo)
    {
        Debug.Log("Mouse pressed on " + gameObject.name);
    }

    public virtual void OnHold(RaycastHit hitInfo)
    {
        Debug.Log("Mouse hold on " + gameObject.name);
    }

    public virtual void OnRelease(RaycastHit hitInfo)
    {
        Debug.Log("Mouse Released on " + gameObject.name);
    }
}
