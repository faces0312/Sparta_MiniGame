using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour
{
    TimeFlow timeFlow;

    // Start is called before the first frame update
    void Start()
    {
        timeFlow = new TimeFlow();
    }

    // Update is called once per frame
    void Update()
    {
        timeFlow.Update();
    }

    public class TimeFlow
    {
        public Text timeText;
        private float remainingTime = 30.00f;

        public void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                timeText.text = "Time: " + remainingTime.ToString("F2") + "seconds";
            }
            else
            {
                timeText.text = "Time: 0.00 seconds";
            }
        }
    }
}
