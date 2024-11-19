using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Abstract")]
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected Rigidbody rb;
    #region  LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadShereCollider();
        //this.LoadRigidBody();
    }
    protected virtual void LoadShereCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        if (this.capsuleCollider == null)
            Debug.LogWarning(transform.name + ": Load Shere Collider Fail", gameObject);
        else
        {
            Debug.Log(transform.name + ": Load Shere Collider", gameObject);
            this.capsuleCollider.isTrigger = true;
            this.capsuleCollider.radius = 0.5f;
        }
            

    }   
    protected virtual void LoadRigidBody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        if (this.rb == null)
            Debug.LogWarning(transform.name + ": Load Rigid Body Fail", gameObject);
        else
        {
            Debug.Log(transform.name + ": Load Rigid Body", gameObject);
            this.rb.isKinematic = true;
        }
    }
    #endregion LoadComponents
    protected virtual bool IsEnemy(GameObject obj)
    {
        if (obj.CompareTag ("Junks") || obj.CompareTag("Opponents")) return true;
        return false;
    }
    protected virtual void OnTriggerEnter(Collider other) {
        if (IsEnemy(other.gameObject))
            this.bulletCtrl.DamageSender.Send(other.transform);

    }
}
