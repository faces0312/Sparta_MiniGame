using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float x_Pos;
    private float y_Pos;

    //public int id;
    public BoxCollider2D boxCollider;

    private float x_Range = 2.8f;

    private float speed = 3;

    void OnEnable()
    {
        x_Range = x_Range - boxCollider.size.x / 2f;
        x_Pos = Random.Range(-x_Range, x_Range);
        y_Pos = 5.5f;
        transform.position = new Vector2(x_Pos, y_Pos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * (speed + GM_Suberunker.gm.level * 0.3f) * Time.deltaTime;
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

        if(collision.tag == "Shield")
        {
            GM_Suberunker.gm.shield.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}