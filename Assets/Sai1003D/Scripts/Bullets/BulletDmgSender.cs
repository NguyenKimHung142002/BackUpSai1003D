using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDmgSender : DamageSender
{
    [Header ("Bullet Dmg Sender")]
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
    protected override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DespawnBullet();
    }
    protected virtual void DespawnBullet()
    {
        bulletCtrl.BulletVFXCtrl.SpawnFXOnDead();
        //AudioManager.Instance.FindAndPlay(SoundNameEn.MidExplosion);
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
    
}
