using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GM_Block : MonoBehaviour
{
    public int totalLives = 3;
    public int curLives;
    public TextMeshProUGUI Life;

    // Start is called before the first frame update
    void Start()
    {
        curLives = totalLives;
        Life.text = "Life :" + curLives.ToString();
        Life.text = curLives.ToString();
    }

    public void BallDropped()
    {
        curLives--;
        Life.text = curLives.ToString();
        if (curLives == 0)
        {
            GameOver();
        }
        Life.text = "Life : " + curLives.ToString();
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
    }

}
