using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPool : MonoBehaviour
{
    public GameObject itemPrefab;
    public int poolSize = 10;
    private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();

        // �ʱ� ������Ʈ Ǯ��
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(itemPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    // ������Ʈ Ǯ���� ��� ������ ������Ʈ�� ��������
    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // ������Ʈ Ǯ�� ���� ������Ʈ�� ������ ���� ����
        GameObject newObj = Instantiate(itemPrefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}