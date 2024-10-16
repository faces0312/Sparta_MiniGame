using System.Collections;
using UnityEngine;

public class Item_Shield : Item
{
    public int ShieldTime;
    //public GameObject Shield;
    protected override void ItemEffect()
    {
        Debug.Log("½¯µå");
        //Shield.SetActive(true);
        //StartCoroutine(DisableShieldAfterTime());
    }

    //private IEnumerator DisableShieldAfterTime()
    //{
    //    //yield return new WaitForSeconds(ShieldTime);
    //    //Shield.SetActive(false);
    //}
}
