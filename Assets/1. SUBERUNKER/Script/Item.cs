using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    // Start is called before the first frame update
    private float x_Pos;
    private float y_Pos;
    private float speed = 4.5f;
    public float waitSeconds = 0.5f;
    public int id;

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
            speed = 0;
            StartCoroutine(DisableAfterDelay());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (id == 0)
            {
                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obstacles)
                {
                    obstacle.SetActive(false);
                    Debug.Log("Àå¾Ö¹° ÆÄ±«µÊ");
                }
            }
            if(id == 1)
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.score += 10;
                    Debug.Log("Á¡¼ö Ãß°¡µÊ");
                }
            }
            gameObject.SetActive(false);
        }

    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(waitSeconds);
        speed = 4.5f;
        gameObject.SetActive(false);
    }

}
