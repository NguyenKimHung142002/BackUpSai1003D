using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    [Header ("Item Spawner")]
    protected static ItemSpawner instance;
    public static ItemSpawner Instance { get => instance; }

    //khi vao game thi load component lai 1 lan nua va tao singerton
    protected override void Awake()
    {
        base.Awake();
        if (ItemSpawner.instance != null) Debug.LogError("Only 1 Instance at time");
        ItemSpawner.instance = this;
    }

    public virtual void Drop(List<ItemDrop> dropList, Vector3 pos, Quaternion ros)
    {
        ItemEnum itemEnum = dropList[0].itemSO.itemEnum;
        Transform itemDrop = this.Spawn(itemEnum.ToString(), pos, ros);
        
    }
}
