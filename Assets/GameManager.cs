using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    
    public GameObject Item1;
    public GameObject Item2;
    public int minTime;
    public int maxTime;
    float currTime;
    int random = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        MakeItem(minTime, maxTime);
    }

    public void MakeItem(int minTime, int maxTime)
    {
        if (currTime > random)
        {
            int ramdomItem = Random.Range(0, 2);
            if (ramdomItem == 0)
            {
                Debug.Log(random);
                Instantiate(Item1);
                random = Random.Range(minTime, maxTime);
                currTime = 0;
            }
            else
            {
                Debug.Log(random);
                Instantiate(Item2);
                random = Random.Range(minTime, maxTime);
                currTime = 0;
            }
        }
    }

}
