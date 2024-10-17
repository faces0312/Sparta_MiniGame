using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : Item
{
    public GameObject shield;
    protected override void ItemEffect()
    {
        //TODO :: ½¯µå »ý¼º
        //
        gameObject.SetActive(false);
    }
}
