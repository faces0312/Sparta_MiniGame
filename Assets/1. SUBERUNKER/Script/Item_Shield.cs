using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : Item
{
    public GameObject shield;
    protected override void ItemEffect()
    {
        //TODO :: ���� ����
        //
        gameObject.SetActive(false);
    }
}
