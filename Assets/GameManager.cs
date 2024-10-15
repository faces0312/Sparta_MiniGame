using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public GameObject Item1;
    float currTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > 3)
        {
            MakeItem(Item1);
            currTime = 0;
        }
    }

    public void MakeItem(GameObject item)
    {
        Instantiate(item);
    }
}
