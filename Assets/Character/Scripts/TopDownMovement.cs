using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    // 실제로 이동이 일어날 컴포넌트
    private TopDownConroller controller;
    private Rigidbody2D movementRigidbody;
    private SpriteRenderer spriteRenderer;  // SpriteRenderer 인스턴스

    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<TopDownConroller>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();  // SpriteRenderer 초기화
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
        Flip(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        movementRigidbody.velocity = direction;
    }


    private void Flip(Vector2 direction)
    {
        direction = direction * 5;
        movementRigidbody.velocity = direction;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;  // spriteRenderer를 사용하여 flipX 설정
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;  // 왼쪽 방향으로 이동 시 flipX 적용
        }
    }
}
