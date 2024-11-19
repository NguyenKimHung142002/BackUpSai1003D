using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : AutoMonoBehaviour
{
    [Header("Damage Sender")]
    [SerializeField] protected float damgeValue = 1;

    public virtual void Send (Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }
    protected virtual void Send (DamageReceiver damageReceiver)
    {
        damageReceiver.Subtract(this.damgeValue);
    }

}
