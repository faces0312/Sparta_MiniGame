using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]private GameObject playerPaddle;
    private Rigidbody2D rb;

    private float ballSpeed = 5f;

    private float damage;

    private Vector2 ballDir;
    private bool isTouched;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            ballDir = Vector2.Reflect(ballDir, collision.contacts[0].normal);
        }
        else if (collision.gameObject.tag == "Player")
        {
            // 기본 방향 계산
            ballDir = Vector2.Reflect(ballDir, collision.contacts[0].normal);

            // 약간의 각도 변화가 발생 -15도에서 15도 사이로 변경
            // collision.contacts[0].point.x

            if (collision.contacts[0].point.x < playerPaddle.transform.position.x)
            {
                float angleOffsetLeft = Random.Range(-30f, 0f);
                ballDir = Quaternion.Euler(0, 0, angleOffsetLeft) * ballDir;
            }
            else if (collision.contacts[0].point.x > playerPaddle.transform.position.x)
            {
                float angleOffsetRight = Random.Range(0f, 30f);
                ballDir = Quaternion.Euler(0, 0, angleOffsetRight) * ballDir;
            }
        }
    }
    private void Start()
    {
        ballDir = Vector2.up.normalized;
    }
    void Update()
    {
        if (isTouched)
        {
            Vector3 playerPaddlePos = GameObject.Find("PlayerPaddle").transform.position;

            Vector3 ballPos = playerPaddlePos;
            ballPos.y += 0.1f;
            transform.position = ballPos;
        }
        else
        {
            transform.Translate(ballDir * ballSpeed * Time.deltaTime);
        }
    }

    public void SetBall(float _speed, float _damage, bool _isTouched = false)
    {
        isTouched = !_isTouched;
        ballSpeed = _speed;
        damage = _damage;
    }
}
