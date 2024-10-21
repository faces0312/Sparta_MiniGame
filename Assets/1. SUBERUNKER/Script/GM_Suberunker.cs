using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM_Suberunker : MonoBehaviour
{
    public static GM_Suberunker gm;


    //레벨 난이도 관련
    public Object_Pool object_Pool;
    public TextMeshProUGUI level_Text;
    public int level;

    //점수 관련
    public float score = 0;
    public TextMeshProUGUI score_Text;

    //시간 관련
    private float time = 0;
    public TextMeshProUGUI time_Text;

    public GameObject shield;

    private void Awake()
    {
        gm = this;
        level = 1;
    }

    private void Start()
    {
        Invoke("Level_Up", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        time_Text.text = time.ToString("F2");

        score += Time.deltaTime;
        score_Text.text = score.ToString("F0");

        level_Text.text = "LV : " + level.ToString();
    }

    private void Level_Up()
    {
        level++;
        if(object_Pool.time_Min >= 0.3f)
        {
            object_Pool.time_Max -= 0.2f;
            object_Pool.time_Min -= 0.2f;
        }
        else if(object_Pool.spawn_Num < 3)
            object_Pool.spawn_Num++;

        Invoke("Level_Up", 3.5f);
    }

    public void SpawnObject_Level(int num)
    {
        int obstacle_Ran = Random.Range(0, 10);
        int item_Init = Random.Range(0, 10);

        for(int i=0; i <num; i++)
        {
            if (obstacle_Ran < 7)
                object_Pool.SpawnFromObjectPool("Normal_Obstacle");
            else
                object_Pool.SpawnFromObjectPool("Hard_Obstacle");
        }

        if(item_Init < 3)
        {
            int item_Ran = Random.Range(0, 10);

            if (item_Ran < 7)
                object_Pool.SpawnFromObjectPool("P_Coin");
            else
                object_Pool.SpawnFromObjectPool("P_Rubi");
        }
       
    }
    public void GameOver()
    {
        Invoke("StopTime", 1f);
    }

    void StopTime()
    {
        Time.timeScale = 0f;
    }
}
