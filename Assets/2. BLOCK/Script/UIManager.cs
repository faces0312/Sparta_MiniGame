using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private TMP_Text curTxt;
    [SerializeField] private TMP_Text bestTxt;
    private int curScore;
    private int bestScore;

    public int CurScore
    {
        get { return curScore; }
        set { curScore = value; }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }

    }
    void Start()
    {
        curTxt.text = "현재스코어 : ";
        bestTxt.text = "베스트스코어 : ";
    }

    void Update()
    {
        AddScore();
    }

    void AddScore()
    {
        curTxt.text = $"현재스코어 : {curScore}";
        bestScore = 0;

        if (curScore > bestScore)
        {
            bestScore = curScore;
            bestTxt.text = $"베스트스코어 : {bestScore}";
        }
        else
        {            
            bestTxt.text = $"베스트스코어 : {bestScore}";
        }

    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void PressRestartBtn()
    {
        SceneManager.LoadScene("BrickOutGame");
    }
}
