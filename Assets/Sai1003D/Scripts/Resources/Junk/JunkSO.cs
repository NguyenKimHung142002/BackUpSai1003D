using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Junk Name", menuName = "SciptableObject/Junk")]
public class JunkSO : ScriptableObject
{
    public string junkName = "Junk";
    public float hpMax = 2;
    public float moveSpeed = 10;

    public List<ItemDrop> lItemDrops;

}
