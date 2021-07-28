using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is only to change the mode of diff buttons in our application
/// and hence it extends GazeableButton
/// </summary>
public class ModeButton : GazeableButton
{
    // start and update function are used same as the parent class


    // [SerializeField] makes private or protected variable visible in the editor
    [SerializeField]
    private InputMode mode;

    public override void OnPress(RaycastHit hitInfo)
    {
        // this below line will basically run the OnPress method on GazeableButton 
        // which will take case of color change, selecting and unselecting etc
        // to know more check OnPress in GazeableButton class
        base.OnPress(hitInfo);

        if (parentPanel.currentActiveButton != null)
        {
            Player.instance.activeMode = mode;
        }
    }
}
