using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Right : Obstacle
{
    protected override void Obstacle_Init()
    {
        transform.position = new Vector2(3.5f, -3.7f);
        Invoke("Dis_Obj", 3f);
    }

    void Dis_Obj()
    {
        gameObject.SetActive(false);
    }
    protected override void Obstacle_Move()
    {
        transform.position += Vector3.left * (speed) * Time.deltaTime;
    }
}
