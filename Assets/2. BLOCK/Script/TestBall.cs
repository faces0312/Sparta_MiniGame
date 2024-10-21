using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
}
