using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    private GM_Block GM_Block;
    

    // Start is called before the first frame update
    void Start()
    {
        GM_Block = FindObjectOfType<GM_Block>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int ballCount = GameObject.FindGameObjectsWithTag("Item").Length; //태그는 변경하기

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
        Vector2 pos;

        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        pos = player[0].transform.position;

        transform.position = new Vector2(pos.x, pos.y+2);
        gameObject.SetActive(true);
    }
}
