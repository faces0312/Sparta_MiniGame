using System; //##
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownConroller controller;
    private Rigidbody2D rb; // 같은 오브젝트에 있는 Rigidbody2D 컴포넌트를 담아둘 변수 ##
    private SpriteRenderer spriteRenderer;

    private float speed; // 캐릭터의 스피드를 제어할 변수 ##
    Animator anit; // 같은 오브젝트에 있는 Animator 컴포넌트를 담아둘 변수 ##

    bool isDeath = false; // 죽은 상태를 체크할 bool 변수 ##
    bool isMoving = false;

    private Vector2 movementDirection = Vector2.zero;
    private bool isGrounded = true;  // 땅에 닿아 있는지 여부 확인

    public float jumpForce = 3.5f;  // 점프 힘
    /*public Transform groundCheck;  // 땅 체크 위치
    public LayerMask groundLayer;  // 땅 레이어*/

    private void Awake()
    {
        controller = GetComponent<TopDownConroller>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anit = GetComponent<Animator>();
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
        if (isDeath) return; // 죽음 상태라면 함수를 빠져나감 // ##

        //Move();
        // 땅에 닿아 있는지 체크
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void Move() //##
    {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
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
        if (isDeath) return;
        ApplyMovement(movementDirection);
        Flip(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * speed;
        rb.velocity = new Vector2(direction.x, rb.velocity.y); // 점프 중에도 수평 이동 유지
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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collision) // ##
    {
        /*if (collision.CompareTag("Ground"))
        {
            Debug.Log(collision.name);
            Destroy(gameObject);
        }*/
        if (collision.CompareTag("Obstacle"))
        {
            GM_Suberunker.gm.GameOver();
            isDeath = true;
            GetComponent<PlayerDeath>().Death();
        }
    }

}
