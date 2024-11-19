using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParent : AutoMonoBehaviour
{
    [Header ("Move Parent")]
    [SerializeField] protected float moveSpeed = 10;
    [SerializeField] protected Vector3 direction = Vector3.forward;
    // Update is called once per frame
    protected virtual void OnEnable() {
        
    }
    void FixedUpdate()
    {
        transform.parent.Translate(direction * moveSpeed * Time.fixedDeltaTime);
    }
}
