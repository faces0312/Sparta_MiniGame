using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Block2 : Item_Block
{
    protected override void Item_Effect()
    {
        GM_Block.gm_Block.Item2();
        gameObject.SetActive(false);
    }
}
