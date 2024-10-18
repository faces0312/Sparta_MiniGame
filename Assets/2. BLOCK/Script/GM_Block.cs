using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GM_Block : MonoBehaviour
{
    public int totalLives = 3;
    public int curLives;
    public Text Life;
    public GameObject RetryPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        curLives = totalLives;
        Life.text = "Life :" + curLives.ToString();
    }

    public void BallDropped()
    {
        curLives--;
        if (curLives == 0)
        {
            GameOver();
        }
        Life.text = "Life : " + curLives.ToString();
    }

    public void RetryPanelOn()
    {
        RetryPanel.SetActive(true);
    }

    

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        RetryPanel.SetActive(true);
    }

}
