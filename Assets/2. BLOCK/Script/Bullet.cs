using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject[] bullet;

    private void OnEnable()
    {
        for(int i=0; i<2; i++)
        {
            bullet[i].SetActive(true);
        }
    }

    void Update()
    {
        if(transform.position.y >= 5)
        {
            gameObject.SetActive(false);
        }
        transform.Translate(Vector3.up * 3 * Time.deltaTime);
    }
}
