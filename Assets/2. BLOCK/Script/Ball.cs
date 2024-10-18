using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

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
        // �浹�� ���� ���� ���͸� ������
        // Vector2 normal = collision.contacts[0].normal;

        // �Ի� ���͸� �ݻ� ���ͷ� ��ȯ (�Ի簢 = �ݻ簢)
        // velocity = Vector2.Reflect(velocity, normal);

        if (collision.gameObject.tag == "Wall")
        {
            ballDir = Vector2.Reflect(ballDir, collision.contacts[0].normal);
        }
        else if (collision.gameObject.tag == "Player")
        {
            // �⺻ ���� ���
            ballDir = Vector2.Reflect(ballDir, collision.contacts[0].normal);

            // �ణ�� ���� ��ȭ�� �߻� -15������ 15�� ���̷� ����
            float angleOffset = Random.Range(-15f, 15f); 
            ballDir = Quaternion.Euler(0, 0, angleOffset) * ballDir;

            //SetBall(ballSpeed, damage =1, isTouched);
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
