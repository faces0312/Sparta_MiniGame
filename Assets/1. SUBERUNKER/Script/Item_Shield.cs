using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : Item
{
    public GameObject shield;
    protected override void ItemEffect()
    {
        //TODO :: ½¯µå »ý¼º
        GM_Suberunker.gm.score += 10;
        GM_Suberunker.gm.shield.SetActive(true);
        //
        gameObject.SetActive(false);
    }
}
