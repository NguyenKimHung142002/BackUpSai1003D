using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkDmgReceiver : DamageReceiver
{
    [Header ("Junk dmg control")]
    [SerializeField] protected JunkControl junkControl;
    
    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkControl();
        this.Reborn();
    }
    protected virtual void LoadJunkControl()
    {
        if (this.junkControl != null) return;
        this.junkControl = transform.parent.GetComponent<JunkControl>();
        if (this.junkControl == null)
            Debug.LogWarning(transform.name + ": Load Junk Control Fail", gameObject);
        else
            Debug.Log(transform.name + ": Load Junk Control", gameObject);
        
    }
    
    #endregion LoadComponent 

    protected override void OnDead()
    { 
        this.junkControl.JunkVFX.SpawnFXOnDead();
        this.OnDeadDrop();
        this.junkControl.JunkDespawn.DespawnObject();
    }
    protected override void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRos = transform.rotation;
        ItemSpawner.Instance.Drop(this.junkControl.JunkSO.lItemDrops, dropPos, dropRos);
    }
 
    
   
    // overrite set reborn = gia tri cua Scriptable Object
    public override void Reborn()
    {
        this.hpMax = junkControl.JunkSO.hpMax;
        base.Reborn();
    }
}
