using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Block2 : Item_Block
{
    protected override void Item_Effect()
    {
        GM_Block.instance.Item2();
        gameObject.SetActive(false);
    }
}
