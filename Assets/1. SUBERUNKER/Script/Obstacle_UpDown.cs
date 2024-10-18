using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_UpDown : Obstacle
{
    protected override void Obstacle_Init()
    {
        x_Range = x_Range - boxCollider.size.x / 2f;
        x_Pos = Random.Range(-x_Range, x_Range);
        y_Pos = 5.5f;
        transform.position = new Vector2(x_Pos, y_Pos);
    }

    protected override void Obstacle_Move()
    {
        transform.position += Vector3.down * (speed + GM_Suberunker.gm.level * 0.3f) * Time.deltaTime;
    }
}
