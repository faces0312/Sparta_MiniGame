using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Score : Item
{
    protected override void ItemEffect()
    {
        //TODO :: 추가 점수
        //
        gameObject.SetActive(false);
    }
}
