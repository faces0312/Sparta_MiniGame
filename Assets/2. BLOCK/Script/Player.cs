using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerPaddle : MonoBehaviour
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

        if (transform.position.x < -1.95f)
        {
            curPos.x = -1.95f;
        }
        else if (transform.position.x > 1.95f)
        {
            curPos.x = 1.95f;
        }
        transform.position = curPos;
        transform.Translate(input.dir * speed * Time.deltaTime, 0, 0);
    }
}
