using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public GameObject fade;
    public void DdongStart()
    {
        fade.SetActive(true);
        Invoke("Ddong", 1f);
    }
    public void BlockStart()
    {
        fade.SetActive(true);
        Invoke("Block", 1f);
    }

    public void Ddong()
    {
        SceneManager.LoadScene("SUBERUNKER");
    }

    public void Block()
    {
        SceneManager.LoadScene("BrickOutGame");
    }


}
