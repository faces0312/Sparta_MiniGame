using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour
{
    public TextMeshProUGUI time_Text;
    float time;

    private void Start()
    {
        time = 0f;
    }
    private void Update()
    {
        time += Time.deltaTime;
        time_Text.text = time.ToString("F2");
    }
}