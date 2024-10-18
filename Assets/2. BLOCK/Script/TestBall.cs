using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    private GM_Block GM_Block;
    public int ballCount;

    void Start()
    {
        GM_Block = FindObjectOfType<GM_Block>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length; //태그는 변경하기

        if (collision.gameObject.tag == "Ground")
        {
            if (ballCount == 1)
            {
                GM_Block.BallDropped();
                gameObject.SetActive(false);
                Invoke("ResetBall", 1f);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }

    private void ResetBall()
    {

        //Vector2 pos;

        //GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        //pos = player[0].transform.position;

        transform.position = new Vector2(0, -3.8f);
        gameObject.SetActive(true);
    }
}
