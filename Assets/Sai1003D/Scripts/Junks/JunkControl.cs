using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkControl : AutoMonoBehaviour
{
    [SerializeField] protected JunkDespawn junkDespawn;
    [SerializeField] protected JunkVFX junkVFX;
    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO => junkSO;
    public JunkVFX JunkVFX {get => junkVFX;}
    public JunkDespawn JunkDespawn {get => junkDespawn;}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
        this.LoadJunkVFX();

    }
    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = GetComponentInChildren<JunkDespawn>();
        if (this.junkDespawn == null)
            Debug.LogWarning(transform.name + ": Load Junk Despawn Fail", gameObject);
        else
            Debug.Log(transform.name + ": Load Junk Despawn", gameObject);

    }
    protected virtual void LoadJunkSO()
    {
        if (this.junkSO != null) return;
        string resPath = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(resPath);
        if (this.junkSO == null)
            Debug.LogWarning(transform.name + ": Load Junk Scriptable Object Fail", gameObject);
        else
            Debug.Log(transform.name + ": Load Scriptable Object: " + junkSO.name, gameObject);
    }
    protected virtual void LoadJunkVFX()
    {
        if (this.junkVFX != null) return;
        this.junkVFX = GetComponentInChildren<JunkVFX>();
        if (this.junkVFX == null)
            Debug.LogWarning(transform.name + ": Load Junk VFX Fail", gameObject);
        else
            Debug.Log(transform.name + ": Load Junk VFX", gameObject);
    }
}
