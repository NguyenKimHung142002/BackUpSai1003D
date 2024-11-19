using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVFX : AutoMonoBehaviour
{
    [Header("VFX Reset")]
    [SerializeField] protected List<Transform> lVFX;
    [SerializeField] protected float delayTime = 0.2f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListVFX();
    }
    public virtual void LoadListVFX()
    {
        if (lVFX.Count > 0) return;
        foreach (Transform obj in this.transform)
        {
            this.lVFX.Add(obj);
        }
        if (lVFX.Count == 0) Debug.LogWarning(transform.name + ": Load List VFX count 0", gameObject);
        else Debug.Log(transform.name + ": Load List VFX", gameObject);
    }
    public virtual void SetVFXGameObjectFalse()
    {
        if (lVFX.Count == 0) return;
        foreach(Transform obj in lVFX)
        {
            obj.gameObject.SetActive(false);

        }

    }
    public virtual void SetVFXGameObjectTrue()
    {
       if (lVFX.Count == 0) return;
       StartCoroutine(SetVFXTrue()); 
    }
    protected virtual IEnumerator SetVFXTrue()
    {
        yield return new WaitForSeconds(delayTime);
        
        foreach(Transform obj in lVFX)
        {
            obj.gameObject.SetActive(true);
        }
    }
}
