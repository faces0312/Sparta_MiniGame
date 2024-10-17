using System.Collections;
using UnityEngine;

public class Item_Shield : Item
{
    public static player player;
    protected override void ItemEffect()
    {
        player = new player();
        Debug.Log("½¯µå");
    }

    //private IEnumerator DisableShieldAfterTime()
    //{
    //    //yield return new WaitForSeconds(ShieldTime);
    //    //Shield.SetActive(false);
    //}
}
