using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb; // ���� ������Ʈ�� �ִ� Rigidbody2D ������Ʈ�� ��Ƶ� ���� ##
    Animator anit; // ���� ������Ʈ�� �ִ� Animator ������Ʈ�� ��Ƶ� ���� ##

    private bool isDeath = false; // ���� ���¸� üũ�� bool ���� ##

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ���� ������Ʈ�� �ִ� Rigidbody2D ������Ʈ�� rb������ �Ҵ� ##
        anit = GetComponent<Animator>();
        // ���� ������Ʈ�� �ִ� Animator ������Ʈ�� anit ������ �Ҵ� ##
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
    isDeath = true; // ���� ���·� ����

    anit.SetTrigger("Death"); // ���� �ִϸ��̼� �÷���
                              //Destroy(gameObject, 1f); // 1�� �� ������Ʈ ����
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

    





