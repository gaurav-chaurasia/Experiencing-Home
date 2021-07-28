using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvas : MonoBehaviour
{
    // to keep track of current active button
    public GazeableButton currentActiveButton;

    public Color unselectedColor = Color.white;
    public Color selectedColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this will basically set the active button and do the stuff
    // whenever any button is pressed it will set it to currentActiveButton
    public void SetActiveButton(GazeableButton activeButton)
    {
        // if we have curentlly any active button then it reset the color of the button
        if (currentActiveButton != null)
        {
            currentActiveButton.SetButtonColor(unselectedColor);
        }

        if (activeButton != null && currentActiveButton != activeButton)
        {
            currentActiveButton = activeButton;
            currentActiveButton.SetButtonColor(selectedColor);
        }
        else
        {
            Debug.Log("Resetting ");
            currentActiveButton = null;
            Player.instance.activeMode = InputMode.NONE;
        }
    }
}
