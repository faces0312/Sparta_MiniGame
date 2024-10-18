using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float dir;
    Keyboard keyborad;
    

    void Start()
    {
        keyborad = Keyboard.current;
    }

    void Update()
    {
        if (keyborad.aKey.isPressed)
        {
            dir = -1;
        }
        else if (keyborad.dKey.isPressed)
        {
            dir = 1;
        }
        else 
        {
            dir = 0; 
        }
    }
}
