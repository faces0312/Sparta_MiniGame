using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_Suberunker : MonoBehaviour
{
    public static GM_Suberunker gm;

    public GameObject endPanel;
    public TextMeshProUGUI endPannel_LV;
    public TextMeshProUGUI endPannel_Score;
    //public Text nowScore;

    //ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½Ìµï¿½ ï¿½ï¿½ï¿½ï¿½
    //·¹º§ ³­ÀÌµµ °ü·Ã
    public Object_Pool object_Pool;
    public TextMeshProUGUI level_Text;
    public int level;

    //ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
    public float score = 0;
    public TextMeshProUGUI score_Text;

    //ï¿½Ã°ï¿½ ï¿½ï¿½ï¿½ï¿½
    private float time = 0;
    public TextMeshProUGUI time_Text;

    public GameObject player;
    public GameObject shield;

    private void Awake()
    {
        Time.timeScale = 1;
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
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Start");
        }
            
        shield.transform.position = player.transform.position;

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
        int obstacle_SideRan = Random.Range(0, 10);

        for (int i=0; i <num; i++)
        {
            if (obstacle_Ran < 7)
                object_Pool.SpawnFromObjectPool("Normal_Obstacle");
            else
                object_Pool.SpawnFromObjectPool("Hard_Obstacle");
        }

        if (obstacle_SideRan < 3)
        {
            int side_Ran = Random.Range(0, 2);

            if (side_Ran < 1)
                object_Pool.SpawnFromObjectPool("Left_Obstacle");
            else
                object_Pool.SpawnFromObjectPool("Right_Obstacle");
        }

        if (item_Init < 3)
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
        Time.timeScale = 0.0f;
        //nowScore.text = time.ToString("N2");
        endPanel.SetActive(true);
        endPannel_LV.text = "LV : " + level.ToString();
        endPannel_Score.text = "SCORE : " + score.ToString("F0");
        Debug.Log("Call");
    }

    public void Restart()
    {
        SceneManager.LoadScene("SUBERUNKER");
    }
}
