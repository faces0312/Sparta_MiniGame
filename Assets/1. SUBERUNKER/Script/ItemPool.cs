using System.Collections.Generic;
using UnityEngine;


public class ItemPool : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject itemPrefab2;

    public int poolSize = 10;
    private List<GameObject> pool;


    void Start()
    {
        pool = new List<GameObject>();

        // �ʱ� ������Ʈ Ǯ��
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj;
            if (i % 2 == 0)
            {
                obj = Instantiate(itemPrefab);
            }
            else
            {
                obj = Instantiate(itemPrefab2);
            }
            obj.SetActive(false);
            pool.Add(obj);
        }

    }

    // ������Ʈ Ǯ���� ��� ������ ������Ʈ�� ��������
    public GameObject GetPooledObject()
    {
        List<GameObject> inactiveObjects = new List<GameObject>();

        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                inactiveObjects.Add(obj);
            }
        }

        if (inactiveObjects.Count == 0)
        {
            GameObject newObj;
            if (Random.Range(0, 2) == 0)
            {
                newObj = Instantiate(itemPrefab);
            }
            else
            {
                newObj = Instantiate(itemPrefab2);
            }
            newObj.SetActive(false);
            pool.Add(newObj);
            return newObj;
        }
        int randomIndex = Random.Range(0, inactiveObjects.Count);
        return inactiveObjects[randomIndex];
    }
}



