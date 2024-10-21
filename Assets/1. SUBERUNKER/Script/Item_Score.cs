using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Score : Item
{
    protected override void ItemEffect()
    {
        //TODO :: �߰� ����
        GM_Suberunker.gm.score += 100;
        //
        gameObject.SetActive(false);
    }
}
