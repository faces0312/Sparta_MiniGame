using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    private int speed = 5;
    private PlayerPaddleInput input;
    [SerializeField]private CapsuleCollider2D capsuleColl;
    private float limitX;
    private float paddleHalfSize;

    void Start()
    {
        input = GetComponent<PlayerPaddleInput>();
        gameObject.transform.position = new Vector3(0f,-4f,0f);
        capsuleColl = GetComponentInChildren<CapsuleCollider2D>();
        paddleHalfSize = capsuleColl.size.x / 2f;
        limitX = 2.6f - paddleHalfSize; //오른쪽 Paddle의 중앙시 최대X값
    }

    void Update()
    {
        PaddleMoving();
    }

    private void PaddleMoving()
    {
        Vector3 curPos = transform.position;
        //= curPos.x = Mathf.Clamp(curPos.x , -2f, 2f) 동일
        if (curPos.x < -limitX)
        {
            curPos.x = -limitX;
        }
        else if (curPos.x > limitX)
        {
            curPos.x = limitX;
        }

        transform.position = curPos;
        transform.Translate(input.dir * speed * Time.deltaTime, 0, 0);
    }
}
