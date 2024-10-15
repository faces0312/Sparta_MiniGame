using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float x_Pos;
    private float y_Pos;

    public int id;
    private float speed = 3;

    protected virtual void OnEnable()
    {
        if(id == 1)
            x_Pos = Random.Range(-2.5f, 2.5f);
        else if (id == 2)
            x_Pos = Random.Range(-2.2f, 2.2f);
        y_Pos = 5.5f;

        transform.position = new Vector2(x_Pos, y_Pos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //게임 오버

            //
            Time.timeScale = 0;
        }
        
        if(collision.tag == "Ground")
            gameObject.SetActive(false);
    }
}