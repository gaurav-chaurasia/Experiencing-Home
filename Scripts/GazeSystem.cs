using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSystem : MonoBehaviour
{
    // @reticle is the small spherical object that we have in front of 
    // camera and which we are using to select anything on screen
    public GameObject reticle;

    public Color inactiveReticleColor = Color.gray;
    public Color activeReticleColor = Color.green;

    // @currentGazeObject refers to the object that we are currently stairing at
    private GazeableObject currentGazeObject;    
    // @currentSelectedObject refers to the object on which currently button is pressed on
    private GazeableObject currentSelectedObject;
    private RaycastHit lastHit;

    // Start is called before the first frame update
    void Start()
    {
        SetReticleColor(inactiveReticleColor);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessGaze();
        CheckForInput(lastHit);
    }

    /**
     * @ProcessGaze() method
     * process the gaze object interactions like when we move and staire somthing, stop stairing
     * and many more
     */
    public void ProcessGaze()
    {
        Ray raycastRay = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(raycastRay.origin, raycastRay.direction * 100);

        if (Physics.Raycast(raycastRay, out hitInfo))
        {
            // 1: check if the object is interactable
            
            // get the GameObject from the hitInfo
            // below code will get the currentObject which we are looking at
            GameObject hitObj = hitInfo.collider.gameObject;

            // get the GazebaleObject from the hit object
            // also @gazeObj would be null if the object we are looking at is not GazeableObject 
            GazeableObject gazeObj = hitObj.GetComponentInParent<GazeableObject>();

            // object has a GazeableObject component
            if (gazeObj != null)
            {
                // object we're looking at is different
                if (gazeObj != currentGazeObject)
                {
                    ClearCurrentObject();
                    currentGazeObject = gazeObj;
                    currentGazeObject.OnGazeEnter(hitInfo);

                    // set reticle color
                    SetReticleColor(activeReticleColor);
                }
                else 
                {
                    // else means we are looking at the same object as erlier
                    currentGazeObject.OnGaze(hitInfo);
                }
            }
            else
            {
                // else means we are looking at a non GazeableObject
                ClearCurrentObject();
            }

            lastHit = hitInfo;
        }
        else
        {
            ClearCurrentObject();
        }
    }

    /***
     * @SetReticleColor method sets the color of the gaze object that 
     * we have in front of our camera
     */
    private void SetReticleColor(Color reticleColor)
    {
        // set the color of the reticle 
        reticle.GetComponent<Renderer>().material.SetColor("_Color", reticleColor);
    }

    /***
     * 
     */
    private void CheckForInput(RaycastHit hitInfo)
    {
        // check for down 
        if (Input.GetMouseButtonDown(0) && currentGazeObject != null)
        {
            currentSelectedObject = currentGazeObject;
            currentSelectedObject.OnPress(hitInfo);
        }

        // check for hold
        if (Input.GetMouseButton(0) && currentGazeObject != null)
        {
            currentSelectedObject.OnHold(hitInfo);
        }

        // check for release
        if (Input.GetMouseButtonUp(0) && currentGazeObject != null)
        {
            currentSelectedObject.OnRelease(hitInfo);
            currentSelectedObject = null;
        }
    }

    private void ClearCurrentObject()
    {
        if (currentGazeObject != null)
        {
            // when clearing we call @OnGazeExit method
            currentGazeObject.OnGazeExit();

            // then setting the color of reticle back to default (gray)
            SetReticleColor(inactiveReticleColor);

            // clear the object as we are no longer looking at it
            currentGazeObject = null;
        }
    }
}
