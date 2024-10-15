using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float x_Pos;
    private float y_Pos;
    public int type;
    private float speed = 3;
    public float waitSeconds = 0.5f;
    public GameObject Sheild;
    protected virtual void OnEnable()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(DisableAfterDelay());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Sheild.SetActive(true);
        }

    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(waitSeconds);
        gameObject.SetActive(false);
    }

}
    