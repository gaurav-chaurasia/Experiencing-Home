using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// whenever we add the this script to any button
// this below line will enforce that it has Image component
[RequireComponent(typeof(Image))]
public class GazeableButton : GazeableObject
{
    // declaring variable to keep reference of parent panel of button
    protected VRCanvas parentPanel;

    // Start is called before the first frame update
    void Start()
    {
        parentPanel = GetComponentInParent<VRCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonColor (Color buttonColor)
    {
        // we saw that the background is in Image component of the Button
        // so we are selecting that Image component and setting the color attribute
        GetComponent<Image>().color = buttonColor;
    }

    public override void OnPress(RaycastHit hitInfo)
    {
        // this below line will basically run the OnPress method on GazeableObject
        // which will basically Debug.Log()
        // to know more check OnPress in GazeableObject class
        base.OnPress(hitInfo);

        // giving current active button as parameter
        // and SetActiveButton method going to set everythings for us
        parentPanel.SetActiveButton(this);
    }
}
