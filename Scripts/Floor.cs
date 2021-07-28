using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this class will make floor Gazeable and then after selecting any button
/// </summary>
public class Floor : GazeableObject
{
    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        // checking for player's active mode
        if (Player.instance.activeMode == InputMode.TELEPORT)
        {
            // hitInfo has the point where ray hits the floor on hitInfo.point
            // we are storing it into the destination variable to use later
            Vector3 destination = hitInfo.point;

            // to keep height of player same as erlier 
            // otherwise player will go into the ground 
            destination.y = Player.instance.transform.position.y;

            // change player's position to the destination position
            Player.instance.transform.position = destination;
        }

    }
}
