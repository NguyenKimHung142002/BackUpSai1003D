using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByTime
{

    protected override void Start()
    {
        base.Start();
       
    }

    public override void DespawnObject()
    {
        ItemSpawner.Instance.DeSpawn(transform.parent);
    }
}
