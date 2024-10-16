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

    public int hp;
    public bool is_Stone;//고정블록인지
    public bool is_Item;//아이템블록인지

    private void OnEnable()
    {
        Block_Select();
    }

    public void Block_Select()
    {
        hp = 1;
        is_Stone = false;
        is_Item = false;
        for (int i=0; i<4; i++)
        {
            block_Kind[i].gameObject.SetActive(false);
        }

        int numRan = Random.Range(0, 100);
        if(numRan < 50)
        {
            block_Kind[0].gameObject.SetActive(true);
            //block = new BlockA(1);
        }
        else if (numRan < 70)
        {
            hp = 2;
            block_Kind[1].gameObject.SetActive(true);
            //block = new BlockB();
        }
        else if (numRan < 80)
        {
            block_List.bolckAmount -= 1;
            hp = int.MaxValue;
            is_Stone = true;
            block_Kind[2].gameObject.SetActive(true);
           //block = new BlockC();
        }
        else
        {
            is_Item = true;
            block_Kind[3].gameObject.SetActive(true);
            //block = new BlockD();
        }
        //block.Block_Behaviour();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            hp--;

            //만약 강화블록이면 이미지 변화
            //block.Block_Behaviour();
            //

            if(hp <= 0 && is_Stone == false)
            {
                //만약 아이템 블록이라면 아이템이 떨어져야 함
                
                //
                gameObject.SetActive(false);
            }
        }
    }
}
/*
public abstract class IBlock
{
    protected int hp = 0;

    protected IBlock(int _hp)
    {
        this.hp = _hp;
    }

    public abstract void Block_Behaviour();
}

public class BlockA : IBlock
{
    public BlockA(int _hp) : base(_hp)
    {

    }

    public override void Block_Behaviour()
    {
        Debug.Log("blockA");
    }
}

public class BlockB : IBlock
{
    public override void Block_Behaviour()
    {
        Debug.Log("blockB");
    }
}

public class BlockC : IBlock
{
    public override void Block_Behaviour()
    {
        Debug.Log("blockC");
    }
}

public class BlockD : IBlock
{
    public override void Block_Behaviour()
    {
        Debug.Log("blockD");
    }
}*/
