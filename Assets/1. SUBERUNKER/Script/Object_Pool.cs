using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Object_Pool : MonoBehaviour
{
    public float time_Min;
    public float time_Max;

    private float time = 0;

    // 오브젝트 풀 데이터를 정의할 데이터 모음 정의
    [System.Serializable]
    public class ObectPool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public class ObectPool2
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<ObectPool> objectPools;
    public Dictionary<string, Queue<GameObject>> objectPoolsDictionary;

    private void Awake()
    {
        ObjectInit();
    }

    private void Start()
    {
        time_Max = 3f;
        time_Min = 2.5f;
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
        {
            time = Random.Range(time_Min, time_Max);
            GM_Suberunker.gm.SpawnObject_Level();
        }
    }

    private void ObjectInit()
    {
        objectPoolsDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (ObectPool pool in objectPools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            objectPoolsDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromObjectPool(string tag)
    {
        if (!objectPoolsDictionary.ContainsKey(tag))
            return null;

        GameObject obj = objectPoolsDictionary[tag].Dequeue();
        objectPoolsDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}
