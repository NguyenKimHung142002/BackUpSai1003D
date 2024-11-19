using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : AutoMonoBehaviour
{
    [Header ("Bullet Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => bulletCtrl;}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl ()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        if (this.bulletCtrl == null)
            Debug.LogWarning(transform.name + " Load BulletCtrl fail", gameObject);
        else
            Debug.Log(transform.name + " Load BulletCtrl", gameObject);

    }
}
