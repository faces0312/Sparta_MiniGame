using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;  // 캐릭터의 SpriteRenderer 참조
    private Rigidbody2D movementRigidbody; // 캐릭터의 Rigidbody2D 참조
    public Sprite hitSprite; // 충돌 시 보여줄 스프라이트
    public float stopDelay = 0f; // 충돌 후 움직임이 멈추는 딜레이 (필요시)

    private void Awake()
    {
        // 캐릭터의 SpriteRenderer와 Rigidbody2D 컴포넌트를 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    // 충돌이 발생했을 때 호출되는 메서드
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 "FallingObstacle" 태그를 가진 경우에만 처리
        if (collision.gameObject.CompareTag("FallingObstacle"))
        {
            ChangeSprite(); // 스프라이트 변경
            StopMovement(); // 캐릭터 움직임 멈
        }
    }
    // 스프라이트를 변경하는 메서드
    private void ChangeSprite()
    {
        // 캐릭터의 스프라이트를 충돌 시 스프라이트로 변경
        spriteRenderer.sprite = hitSprite;
    }
    // 캐릭터의 움직임을 멈추는 메서드
    private void StopMovement()
    {
        // Rigidbody2D의 속도를 0으로 설정하여 즉시 멈춤
        movementRigidbody.velocity = Vector2.zero;

        // 만약 Rigidbody2D의 물리 상호작용을 완전히 멈추고 싶다면, Rigidbody2D를 비활성화
        movementRigidbody.isKinematic = true;  // 캐릭터가 물리적인 영향을 받지 않게 설정
    }
}

