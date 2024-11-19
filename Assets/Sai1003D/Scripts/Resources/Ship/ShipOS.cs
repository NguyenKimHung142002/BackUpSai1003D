using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ship Name", menuName = "SciptableObject/Ship")]
public class ShipOS : ScriptableObject
{
    public string shipName = "Ship";
    public float hpMax = 2;
    public float moveSpeed = 10;
    public float fireRate = 0.5f;
    public List<ItemDrop> lItemDrops;

}
