using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    private int speed = 5;
    private PlayerPaddleInput input;
    private GameObject playerPaddle;

    void Start()
    {
        input = GetComponent<PlayerPaddleInput>();
        playerPaddle.transform.position = new Vector3(0f,-4f,0f);
    }

    void Update()
    {
        PaddleMoving();
    }

    private void PaddleMoving()
    {
        Vector3 curPos = transform.position;
        //= curPos.x = Mathf.Clamp(curPos.x , 2f, 2f) µø¿œ
        if (curPos.x < -2f)
        {
            curPos.x = -2f;
        }
        else if (curPos.x > 2f)
        {
            curPos.x = 2f;
        }

        transform.position = curPos;
        transform.Translate(input.dir * speed * Time.deltaTime, 0, 0);
    }
}
