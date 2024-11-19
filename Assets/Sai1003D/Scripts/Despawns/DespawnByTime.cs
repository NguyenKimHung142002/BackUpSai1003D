using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [Header ("Despawn By Time")]
    [SerializeField] protected float timeDelay = 2f;
    protected float timer = 0;
    protected override void OnEnable() {
        base.OnEnable();
        this.ResetTimer();
    }   
    protected virtual void ResetTimer()
    {
        this.timer = 0;
    }
    protected override bool CanDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeDelay) return false;
        return true;
    }

}
