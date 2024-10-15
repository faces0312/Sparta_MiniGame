using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float x_Pos;
    private float y_Pos;
    public int type;
    private float speed = 3;

    protected virtual void OnEnable()
    {
        if (type == 1)
            x_Pos = Random.Range(-2.5f, 2.5f);
        else if (type == 2)
            x_Pos = Random.Range(-2.2f, 2.2f);
        y_Pos = 5.5f;

        transform.position = new Vector2(x_Pos, y_Pos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject,1.0f);
        }
    }


}
