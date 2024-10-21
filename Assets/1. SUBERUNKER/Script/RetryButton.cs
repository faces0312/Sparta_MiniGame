using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
 public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Suberunker");
    }
}
