using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Name", menuName = "SciptableObject/Item")]
public class ItemSO : ScriptableObject
{
    public ItemEnum itemEnum = ItemEnum.NoItem;
    public string itemType = "";
}
