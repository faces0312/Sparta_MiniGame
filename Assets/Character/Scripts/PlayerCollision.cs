using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;  // ĳ������ SpriteRenderer ����
    private Rigidbody2D movementRigidbody; // ĳ������ Rigidbody2D ����
    public Sprite hitSprite; // �浹 �� ������ ��������Ʈ
    public float stopDelay = 0f; // �浹 �� �������� ���ߴ� ������ (�ʿ��)

    private void Awake()
    {
        // ĳ������ SpriteRenderer�� Rigidbody2D ������Ʈ�� ������
        spriteRenderer = GetComponent<SpriteRenderer>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    // �浹�� �߻����� �� ȣ��Ǵ� �޼���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ������Ʈ�� "FallingObstacle" �±׸� ���� ��쿡�� ó��
        if (collision.gameObject.CompareTag("FallingObstacle"))
        {
            ChangeSprite(); // ��������Ʈ ����
            StopMovement(); // ĳ���� ������ ��
        }
    }
    // ��������Ʈ�� �����ϴ� �޼���
    private void ChangeSprite()
    {
        // ĳ������ ��������Ʈ�� �浹 �� ��������Ʈ�� ����
        spriteRenderer.sprite = hitSprite;
    }
    // ĳ������ �������� ���ߴ� �޼���
    private void StopMovement()
    {
        // Rigidbody2D�� �ӵ��� 0���� �����Ͽ� ��� ����
        movementRigidbody.velocity = Vector2.zero;

        // ���� Rigidbody2D�� ���� ��ȣ�ۿ��� ������ ���߰� �ʹٸ�, Rigidbody2D�� ��Ȱ��ȭ
        movementRigidbody.isKinematic = true;  // ĳ���Ͱ� �������� ������ ���� �ʰ� ����
    }
}

