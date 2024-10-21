using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb; // 같은 오브젝트에 있는 Rigidbody2D 컴포넌트를 담아둘 변수 ##
    Animator anit; // 같은 오브젝트에 있는 Animator 컴포넌트를 담아둘 변수 ##

    private bool isDeath = false; // 죽은 상태를 체크할 bool 변수 ##

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 같은 오브젝트에 있는 Rigidbody2D 컴포넌트를 rb변수에 할당 ##
        anit = GetComponent<Animator>();
        // 같은 오브젝트에 있는 Animator 컴포넌트를 anit 변수에 할당 ##
    }

    //private void Update()
    //{
        //if (isDeath) return;

    //}

    //private void Move(Vector2 direction)
    //{
        //float x = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(x * speed, 0);

        //anit.SetBool("isMove", x != 0 ? true : false);

        //if (x != 0 && x != transform.localScale.x)
            //transform.localScale = new Vector3(x * 2, 2, 2);
    //}
    public void Death()
    {
    isDeath = true; // 죽은 상태로 변경

    anit.SetTrigger("Death"); // 죽음 애니메이션 플레이
                              //Destroy(gameObject, 1f); // 1초 뒤 오브젝트 삭제
        GM_Suberunker.gm.GameOver();
    }

    //public void Death()
    //{
        //isDeath = true;

       // anit.SetTrigger("Death");
        //Destroy(gameObject, 1f);

        //Invoke("GameOver", 1f);

    //}
}

    





