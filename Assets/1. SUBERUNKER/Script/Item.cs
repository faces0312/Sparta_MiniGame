using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private float x_Pos;
    private float y_Pos;
    private float speed = 4.5f;
    public float waitSeconds = 0.5f;
    
    //public GameObject Sheild;
    void OnEnable()
    {
        x_Pos = Random.Range(-2.5f, 2.5f);
        y_Pos = 5.5f;

        transform.position = new Vector2(x_Pos, y_Pos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(DisableAfterDelay());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //id값에 따라서 아이템 효과구분
            ItemEffect();

            //Sheild.SetActive(true);
        }

    }

    protected abstract void ItemEffect();


    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(waitSeconds);
        gameObject.SetActive(false);
    }
}
