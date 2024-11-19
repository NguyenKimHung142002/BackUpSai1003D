using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ItemDrop 
{
    public ItemSO itemSO;
    [Range (0, 100)] 
    public int minDrop = 0;
    [Range (0, 100)] 
    public int maxDrop = 1;
    [Range (0, 100)] 
    public float dropRate = 50;

    private void Start()
    {
        CheckMinMax();
    }
    private void CheckMinMax()
    {
        if (minDrop <= maxDrop) return;
        int temp = minDrop;
        minDrop = maxDrop;
        maxDrop = temp;
    }


   
}
