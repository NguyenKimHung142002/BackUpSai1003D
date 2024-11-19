using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
    [SerializeField] protected ParticleSystem parentPS;
    protected override void Start()
    {
        base.Start();
        this.GetPartiDur();
    }
    protected virtual void GetPartiDur()
    {
        parentPS = transform.parent.GetComponent<ParticleSystem>();
        this.timeDelay = parentPS.main.duration;
    }
    public override void DespawnObject()
    {
        FxSpawner.Instance.DeSpawn(transform.parent);
    }
}
