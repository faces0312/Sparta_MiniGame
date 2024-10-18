using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public float x_Pos;
    public float y_Pos;

    //public int id;
    public BoxCollider2D boxCollider;

    public float x_Range = 2.8f;

    public float speed = 3;

    void OnEnable()
    {
        Obstacle_Init();
        /*x_Range = x_Range - boxCollider.size.x / 2f;
        x_Pos = Random.Range(-x_Range, x_Range);
        y_Pos = 5.5f;
        transform.position = new Vector2(x_Pos, y_Pos);*/
    }

    protected abstract void Obstacle_Init();

    // Update is called once per frame
    void Update()
    {
        Obstacle_Move();
    }

    protected abstract void Obstacle_Move();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //게임 오버
            //GM_Suberunker.gm.End_Page();
            //
            Time.timeScale = 0;
        }

        if(collision.tag == "Ground")
            gameObject.SetActive(false);

        if(collision.tag == "Shield")
        {
            GM_Suberunker.gm.shield.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}