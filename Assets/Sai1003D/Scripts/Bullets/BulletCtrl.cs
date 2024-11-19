using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : AutoMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    
    [SerializeField] protected BulletDespawn bulletDespawn;
    [SerializeField] protected BulletVFX bulletVFXCtrl;
    [SerializeField] protected ResetVFX resetVFX;
    public BulletVFX BulletVFXCtrl {get => bulletVFXCtrl;}
    public DamageSender DamageSender {get => damageSender;}
    public BulletDespawn BulletDespawn {get => bulletDespawn;}
    public ResetVFX ResetVFX {get => resetVFX;}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
        this.LoadVFXControl();
        this.LoadResetVFX();
    }
    
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        if (this.damageSender == null) 
            Debug.LogWarning(transform.name + " Load Damage Receiver Fail", gameObject);
        else 
            Debug.Log(transform.name + " Load Damage Receiver", gameObject);
    }
    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        if (this.bulletDespawn == null)
            Debug.LogWarning (transform.name + " Load Bullet Despawn fail", gameObject);
        else 
            Debug.Log(transform.name + " Load Bullet Despawn", gameObject);
    }
    protected virtual void LoadVFXControl ()
    {
        if (this.bulletVFXCtrl != null) return;
        this.bulletVFXCtrl = GetComponentInChildren<BulletVFX>();
        if (this.bulletVFXCtrl == null)
            Debug.LogWarning (transform.name + " Load VFX CTRL fail", gameObject);
        else 
            Debug.Log(transform.name + " Load VFX CTRL", gameObject);
    }
    protected virtual void LoadResetVFX ()
    {
        if (this.resetVFX != null) return;
        this.resetVFX = GetComponentInChildren<ResetVFX>();
        if (this.resetVFX == null)
            Debug.LogWarning (transform.name + " Load Reset VFX fail", gameObject);
        else 
            Debug.Log(transform.name + " Load Reset VFX", gameObject);
    }

    //mỗi khi tạo tên lửa thì sẽ mở lại VFX
    protected virtual void OnEnable() {
        resetVFX.SetVFXGameObjectTrue();
    }
}
