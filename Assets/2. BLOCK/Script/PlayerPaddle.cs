using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    private int speed = 5;
    private PlayerPaddleInput input;

    void Start()
    {
        input = GetComponent<PlayerPaddleInput>();
    }

    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        Vector3 curPos = transform.position;
        
        //= curPos.x = Mathf.Clamp(curPos.x , -1.95f, 1.95f) µø¿œ
        if (curPos.x < -1.95f)
        {
            curPos.x = -1.95f;
        }
        else if (curPos.x > 1.95f)
        {
            curPos.x = 1.95f;
        }

        transform.position = curPos;
        transform.Translate(input.dir * speed * Time.deltaTime, 0, 0);
    }
}
