using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput() 
    {
        if (Input.GetKeyDown("a"))
        {
            ControlEvents.current.CursorLeft();
        }

        if (Input.GetKeyDown("d"))
        {
            ControlEvents.current.CursorRight();
        }
    }
}
