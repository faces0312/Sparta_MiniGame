using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public int minTime;
    public int maxTime;
    float currTime;
    int random = 1;

    public ItemPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > random)
        {
            GameObject item = objectPool.GetPooledObject();
            item.gameObject.SetActive(true);
            currTime = 0;
            random = Random.Range(minTime, maxTime);
            Debug.Log(random);
        }

    }


}


