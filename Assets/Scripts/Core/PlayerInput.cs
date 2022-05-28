using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    
    public float GetHorizontalInput() 
    {
        return fixedJoystick.Horizontal;
    }

    public float GetVerticalInput()
    {
        return fixedJoystick.Vertical;
    }
    
}
