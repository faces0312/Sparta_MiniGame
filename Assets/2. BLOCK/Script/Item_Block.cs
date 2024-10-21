using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Block : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 2 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Item_Effect();
        }
    }

    protected abstract void Item_Effect();
}
