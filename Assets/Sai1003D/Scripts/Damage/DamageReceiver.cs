using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class DamageReceiver : AutoMonoBehaviour
{
    [Header ("Dmg receiver")]
    [SerializeField] protected float hp = 10;
    [SerializeField] protected float hpMax = 10;
    [SerializeField] protected bool isDead = false;
    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }
    protected virtual void OnEnable(){
        this.Reborn();
    }
    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }
    public virtual void Add(float value)
    {
        if (isDead) return;
        this.hp += value;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }
    public virtual void Subtract(float value)
    {
        //if (isDead) return;
        this.hp -= value;
        if (this.hp <= 0) {
            this.hp = 0;
            this.isDead = true; 
        }    
        this.CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {
        if (!this.isDead) return;
        this.OnDead();
    }
    protected abstract void OnDead();
    protected virtual void OnDeadDrop(){}
}
