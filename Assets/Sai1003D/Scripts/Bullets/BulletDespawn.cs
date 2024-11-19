using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();

    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.gameObject.GetComponent<BulletCtrl>();
        if (this.bulletCtrl == null)  Debug.LogWarning(transform.name + ": Load Bullet Ctrl fail", gameObject);
        else Debug.Log(transform.name + ": Load Bullet Ctrl", gameObject);
    }
    public override void DespawnObject()
    {
        
        BulletSpawner.Instance.DeSpawn(transform.parent);
        this.bulletCtrl.ResetVFX.SetVFXGameObjectFalse();
    }   

}
