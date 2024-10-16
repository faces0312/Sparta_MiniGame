using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public class RowArrayBlock
{
    public GameObject[] rowBlock;
}

public class Block_List : MonoBehaviour
{
    //블록의 총 개수
    public int bolckAmount;
    //7칸짜리 5줄의 블록 생성
    public RowArrayBlock[] blockArray;

    void Awake()
    {
        BlockInit();
    }

    public void BlockInit()
    {
        bolckAmount = 35;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 7; j++)
                blockArray[i].rowBlock[j].SetActive(false);
        }


        for (int i=0; i<5; i++)
        {
            for(int j =0; j<7; j++)
            {
                int numRan = Random.Range(0, 5);
                
                if(numRan == 0)
                {
                    bolckAmount -= 1;
                    blockArray[i].rowBlock[j].SetActive(false);
                }
                else
                    blockArray[i].rowBlock[j].SetActive(true);
            }
        }
    }
}
