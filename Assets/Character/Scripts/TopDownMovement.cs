using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownConroller controller;
    private Rigidbody2D movementRigidbody;
    private SpriteRenderer spriteRenderer;

    private Vector2 movementDirection = Vector2.zero;
    private bool isGrounded = true;  // 땅에 닿아 있는지 여부 확인

    public float jumpForce = 7f;  // 점프 힘
    public Transform groundCheck;  // 땅 체크 위치
    public LayerMask groundLayer;  // 땅 레이어

    private void Awake()
    {
        controller = GetComponent<TopDownConroller>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Update()
    {
        // 점프 입력 감지
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // 땅에 닿아 있는지 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
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
        movementRigidbody.velocity = new Vector2(direction.x, movementRigidbody.velocity.y); // 점프 중에도 수평 이동 유지
    }

    private void Flip(Vector2 direction)
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    // 점프 기능 추가
    private void Jump()
    {
        movementRigidbody.velocity = new Vector2(movementRigidbody.velocity.x, jumpForce);
    }
}

