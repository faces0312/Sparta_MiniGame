using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Block : MonoBehaviour
{
    [System.Serializable]
    public class ObectPool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<ObectPool> objectPools;
    public Dictionary<string, Queue<GameObject>> objectPoolsDictionary;
    Queue<GameObject> objectPool = new Queue<GameObject>();

    private void Awake()
    {
        ObjectInit();
    }

    private void ObjectInit()
    {
        objectPoolsDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (ObectPool pool in objectPools)
        {
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            objectPoolsDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromObjectPool(string tag, Vector3 pos)
    {
        if (!objectPoolsDictionary.ContainsKey(tag))
            return null;

        GameObject obj = objectPoolsDictionary[tag].Dequeue();
        objectPoolsDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        obj.transform.position = pos;
        return obj;
    }
    public void DeactivateAllObjects()
    {
        foreach (GameObject _obj in objectPool)
        {
            GameObject obj = _obj;
            obj.SetActive(false);
        }
    }
}
