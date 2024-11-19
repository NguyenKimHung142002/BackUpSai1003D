using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoadVFX : AutoMonoBehaviour
{
    [Header("Load VFX")]
    [SerializeField] protected Transform fxParticle;
    protected override void Start()
    {
        base.Start();
        this.LoadFxParcile();
    }

    protected virtual void LoadFxParcile()
    {
        if ( this.fxParticle != null) return;
        this.fxParticle = FxSpawner.Instance.GetPrefabByName("MedExplosion");
    }

    public virtual void SpawnFXOnDead()
    {

        FxSpawner.Instance.Spawn(fxParticle, this.transform.position, this.transform.rotation);
    }
}
