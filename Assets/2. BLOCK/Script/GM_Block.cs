using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class GM_Block : MonoBehaviour
{

    public static GM_Block gm_Block;
    public Block_List block_List;
    public ObjectPool_Block objectPool;

    public int stage_Level;

    public GameObject player;
    public int ball_Num;

    public int totalLives = 3;
    public int curLives;
    public TextMeshProUGUI Life;

    void Awake()
    {
        gm_Block = this;
        stage_Level = 0;
    }

    private void Start()
    {
        Game_Start();
    }

    private void Update()
    {
        Life.text = block_List.bolckAmount.ToString();
        if (block_List.bolckAmount <= 0)
        {
            StopCoroutine("Bullet_Pool");
            CancelInvoke("Size_Change");
            objectPool.DeactivateAllObjects();
            //Ball�� ���� ������� ��
            /*foreach (ObjectPool_Block.ObectPool pool in objectPool.objectPools)
            {
                pool.prefab.SetActive(false);
            }*/
            Game_Start();
        }
    }

    void Game_Start()
    {
        stage_Level++;
        block_List.BlockInit();
        ball_Num = 1;
        curLives = totalLives;
        Life.text = $"������� :{curLives}";        
        Life.text = block_List.bolckAmount.ToString();

        objectPool.SpawnFromObjectPool("Ball", new Vector2(player.transform.position.x, player.transform.position.y +2));
    }  

    public void BallDropped()
    {
        curLives--;
        Life.text = $"������� :{curLives}";
        if (curLives == 0)
        {
            GameOver();
        }
        Life.text = $"������� :{curLives}";
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    public void Item_Block(Vector2 Pos)
    {
        int num = Random.Range(0,3);

        if(num == 0)
            objectPool.SpawnFromObjectPool("Item1_PaddleSize", Pos);
        else if (num == 1)
        {
            objectPool.SpawnFromObjectPool("Item2_BallNum", Pos);
        }
        else
            objectPool.SpawnFromObjectPool("Item3_Bullet", Pos);
    }

    public void Item1()
    {
        player.transform.localScale= new Vector3(2f, 0.5f);
        CancelInvoke("Size_Change");
        Invoke("Size_Change", 5f);
    }
    void Size_Change()
    {
        player.transform.localScale = new Vector3(1.5f, 0.5f);
    }

    public void Item2()
    {
        ball_Num++;
        objectPool.SpawnFromObjectPool("Ball", new Vector2(player.transform.position.x, player.transform.position.y + 2));
    }

    public void Item3()
    {
        StopCoroutine("Bullet_Pool");
        StartCoroutine("Bullet_Pool");
    }

    IEnumerator Bullet_Pool()
    {
        for(int i=0; i<10; i++)
        {
            objectPool.SpawnFromObjectPool("Bullet", new Vector2(player.transform.position.x, player.transform.position.y + 0.2f));
            yield return new WaitForSeconds(0.5f);
        }
    }
}
