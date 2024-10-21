using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class GM_Block : MonoBehaviour
{
    public static GM_Block instance;

    public ObjectPool_Block objectPool;

    public GameObject player;
    public int ball_Num;

    public int totalLives = 3;
    public int curLives;
    public TextMeshProUGUI Life;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ball_Num = 1;
        curLives = totalLives;
        Life.text = $"巢篮格见 :{curLives}";        

        objectPool.SpawnFromObjectPool("Ball", new Vector2(player.transform.position.x, player.transform.position.y +2));
    }  

    public void BallDropped()
    {
        curLives--;
        Life.text = $"巢篮格见 :{curLives}";
        if (curLives == 0)
        {
            GameOver();
        }
        Life.text = $"巢篮格见 :{curLives}";
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
