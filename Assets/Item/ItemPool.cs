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

        // 초기 오브젝트 풀링
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(itemPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    // 오브젝트 풀에서 사용 가능한 오브젝트를 가져오기
    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // 오브젝트 풀에 남는 오브젝트가 없으면 새로 생성
        GameObject newObj = Instantiate(itemPrefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}