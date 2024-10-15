using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Object_Pool : MonoBehaviour
{
    private float time = 0;

    // 오브젝트 풀 데이터를 정의할 데이터 모음 정의
    [System.Serializable]
    public class ObstaclePool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    [System.Serializable]
    public class ItemPool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<ObstaclePool> obstaclePools;
    public Dictionary<string, Queue<GameObject>> obstaclPoolDictionary;

    public List<ItemPool> itemPools;
    public Dictionary<string, Queue<GameObject>> itemPoolDictionary;

    private void Awake()
    {
        ObstacleInit();
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
        {
            time = Random.Range(1.2f, 2.1f);
            SpawnFromObstaclePool("Normal_Obstacle", 1);
            SpawnFromItemePool("P_Coin", 1);
        }
    }

    private void ObstacleInit()
    {
        obstaclPoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in obstaclePools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            obstaclPoolDictionary.Add(pool.tag, objectPool);
        }
    }

    private void ItemInit()
    {
        itemPoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in itemPools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            itemPoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromObstaclePool(string tag, int id)
    {
        if (!obstaclPoolDictionary.ContainsKey(tag))
            return null;

        GameObject obj = obstaclPoolDictionary[tag].Dequeue();
        Obstacle obs = obj.GetComponent<Obstacle>();
        obs.id = id;
        obstaclPoolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }

    public GameObject SpawnFromItemePool(string tag, int type)
    {
        if (!itemPoolDictionary.ContainsKey(tag))
            return null;

        GameObject item = itemPoolDictionary[tag].Dequeue();
        Item itm = item.GetComponent<Item>();
        itm.type = type;
        itemPoolDictionary[tag].Enqueue(item);
        item.SetActive(true);
        return item;
    }
}
