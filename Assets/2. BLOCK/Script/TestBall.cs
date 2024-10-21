using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    //private GM_Block GM_Block;
    //public int ballCount;

    /*void Start()
    {
        GM_Block = FindObjectOfType<GM_Block>();
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ballCount = GameObject.FindGameObjectsWithTag("Ball").Length; //태그는 변경하기

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(GM_Block.gm_Block.ball_Num);
            if (GM_Block.gm_Block.ball_Num == 1)
            {
                GM_Block.gm_Block.objectPool.SpawnFromObjectPool("Ball", new Vector2(GM_Block.gm_Block.player.transform.position.x, GM_Block.gm_Block.player.transform.position.y + 2));
                GM_Block.gm_Block.curLives--;
                if(GM_Block.gm_Block.curLives <= 0)
                {
                    GM_Block.gm_Block.GameOver();
                }
                gameObject.SetActive(false);
            }
            else
            {
                GM_Block.gm_Block.ball_Num--;
                gameObject.SetActive(false);
            }
        }
    }

    private void ResetBall()
    {
        Vector2 pos;

        /*GameObject[] player = GameObject.FindGameObjectsWithTag("Player");*/

        pos = GM_Block.gm_Block.player.transform.position;

        transform.position = new Vector2(pos.x, pos.y+2);
        gameObject.SetActive(true);
    }
}
