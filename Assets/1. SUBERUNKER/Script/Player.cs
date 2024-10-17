using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    public int ShieldTime;
    public GameObject Shield;
    


    public void ShieldOff()
    {
        Shield.SetActive(false);
    }
    private IEnumerator DisableShieldAfterTime()
    {
        yield return new WaitForSeconds(ShieldTime);
        Shield.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("ShieldOff", 1f);
    }
}
