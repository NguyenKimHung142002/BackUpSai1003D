using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkMove : MoveParent
{
    [Header ("Move Junk")]
    [SerializeField] protected JunkControl junkControl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkControl();
        this.GetSpeedSO();
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
    protected override void OnEnable() {
        base.OnEnable();
        
        //this.ChangeMoveDirection(GetCamTarget());
    }
    protected virtual void GetSpeedSO()
    {
        this.moveSpeed = junkControl.JunkSO.moveSpeed;
    }
    protected virtual Transform GetCamTarget()
    {
        
        return GameController.Instance.MainCamera.transform;
    }
    protected virtual void ChangeMoveDirection(Transform target)
    {   
        Vector3 tarPos = target.position;
        tarPos.y = 0;
        Vector3 parPos = this.transform.parent.position;
        Vector3 diff = tarPos - parPos;
        diff.Normalize();
        float rotationY = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, rotationY, 0);

        Debug.DrawLine(parPos, tarPos, Color.red, Mathf.Infinity);
    }
}
