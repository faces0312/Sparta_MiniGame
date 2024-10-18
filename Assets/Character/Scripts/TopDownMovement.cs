using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownConroller controller;
    private Rigidbody2D movementRigidbody;
    private SpriteRenderer spriteRenderer;

    private float speed;

    private Vector2 movementDirection = Vector2.zero;
    private bool isGrounded = true;  // 땅에 닿아 있는지 여부 확인

    public float jumpForce = 3.5f;  // 점프 힘
    /*public Transform groundCheck;  // 땅 체크 위치
    public LayerMask groundLayer;  // 땅 레이어*/

    private void Awake()
    {
        controller = GetComponent<TopDownConroller>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        speed = 5f;
    }

    private void Update()
    {
        // 점프 입력 감지
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // 땅에 닿아 있는지 체크
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            speed = 5f;
            isGrounded = true;
        }

        /*if(collision.gameObject.tag == "Wall")
        {
            speed = 0f;
            movementRigidbody.velocity = Vector2.zero;
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        /*if (collision.gameObject.tag == "Wall")
        {
            speed = 5f;
        }*/
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
        direction = direction * speed;
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

