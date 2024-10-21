using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public string[] miniGameNames = { "SUBERUNKER", "BrickOutGame" };

    public Text gameTitleText;
    public Button leftArrowButton;
    public Button rightArrowButton;
    public GameObject fade;
    public GameObject backGround;

    private int currGameIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        backGround.SetActive(true);
        leftArrowButton.onClick.AddListener(SelectPreviousGame);
        rightArrowButton.onClick.AddListener(SelectNextGame);
        UpdateGameUI();
    }
    void SelectPreviousGame()
    {
        currGameIndex--;
        if (currGameIndex < 0)
        {
            currGameIndex = miniGameNames.Length - 1;
            UpdateGameUI();
        }
        if (currGameIndex == 0)
        {
            backGround.SetActive(true);
            UpdateGameUI();
        }
        else
        {
            backGround.SetActive(false);
            UpdateGameUI();
        }
        UpdateGameUI();
    }

    // 다음 게임 선택
    void SelectNextGame()
    {
        currGameIndex++;
        if (currGameIndex >= miniGameNames.Length)
        {
            currGameIndex = 0;
            UpdateGameUI();
        }
        if (currGameIndex == 0)
        {
            backGround.SetActive(true);
            UpdateGameUI();
        }
        else
        {
            backGround.SetActive(false);
            UpdateGameUI();
        }
        UpdateGameUI();
    }
    void UpdateGameUI()
    {
        gameTitleText.text = miniGameNames[currGameIndex];
    }
    public void SelectedGame()
    {
        SceneManager.LoadScene(miniGameNames[currGameIndex]);
    }

    public void StartGame()
    {
        fade.SetActive(true);
        Invoke("SelectedGame", 1f);
    }

}
