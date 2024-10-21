using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //블록 종류
    /*
    0. 일반 블록
    1. 강화 블록
    2. 고정 블록
    3. 아이템 블록
    */
    //private IBlock block;

    public Block_List block_List;

    public SpriteRenderer[] block_Kind;//블록 이미지

    public int id;
    public int hp;

    private void OnEnable()
    {
        Block_Select();
        //Block_Choice();
    }

    //protected abstract void Block_Choice();

    public void Block_Select()
    {
        hp = 1;
        for (int i=0; i<5; i++)
        {
            block_Kind[i].gameObject.SetActive(false);
        }

        int numRan = Random.Range(0, 100);
        if(numRan < 50)
        {
            id = 0;
            block_Kind[0].gameObject.SetActive(true);
            //
            //block = new BlockA(1,true, false);
        }
        else if (numRan < 70)
        {
            id = 1;
            hp = 2;
            block_Kind[1].gameObject.SetActive(true);
            //block = new BlockB();
        }
        else if (numRan < 80)
        {
            id = 2;
            block_List.bolckAmount -= 1;
            hp = int.MaxValue;
            block_Kind[3].gameObject.SetActive(true);
           //block = new BlockC();
        }
        else
        {
            id = 3;
            block_Kind[4].gameObject.SetActive(true);
            //block = new BlockD();
        }
        //block.Block_Behaviour();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Block_Hit(id);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Block_Hit(id);
            collision.gameObject.SetActive(false);
        }
    }


    private void Block_Hit(int id)
    {
        if(id == 0)
        {
            //일반 블록
            Debug.Log("일반블록");
            block_List.bolckAmount -= 1;
            gameObject.SetActive(false);
        }
        else if (id == 1)
        {
            //강화 블록
            Debug.Log("강화블록");
            hp--;
            if(hp <= 0)
            {
                block_List.bolckAmount -= 1;
                gameObject.SetActive(false);
            }
            else
            {
                block_Kind[1].gameObject.SetActive(false);
                block_Kind[2].gameObject.SetActive(true);
            }
        }
        else if (id == 2)
        {
            //고정 블록
            Debug.Log("고정블록");
            return;
        }
        else if (id == 3)
        {
            //아이템 블록
            Debug.Log("아이템블록");
            GM_Block.gm_Block.Item_Block(gameObject.transform.position);
            block_List.bolckAmount -= 1;
            gameObject.SetActive(false);
        }
    }
}

/*public interface IBlock
{
    //public int _hp { get; set; }
    
    public abstract void Block_Behaviour();
}

public class Block_Normal : Block, IBlock
{
    //public int _hp { get; set; }

    //public int hp { }
    public void Block_Behaviour()
    {
        Debug.Log(hp);
    }

    protected override void Block_Choice()
    {
        block_Kind[0].gameObject.SetActive(true);
    }
}*/

