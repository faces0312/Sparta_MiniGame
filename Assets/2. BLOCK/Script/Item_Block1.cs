using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Block1 : Item_Block
{
    protected override void Item_Effect()
    {
        GM_Block.gm_Block.Item1();
        gameObject.SetActive(false);
    }

}
