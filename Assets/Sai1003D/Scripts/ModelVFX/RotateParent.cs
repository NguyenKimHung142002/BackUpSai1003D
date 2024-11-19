using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateParent : MonoBehaviour
{
    [SerializeField] protected float speed = 10;
    [SerializeField] protected Vector3 rotateDirection = Vector3.right;
    void FixedUpdate()
    {
        this.Rotate();
    }
    protected virtual void Rotate()
    {
        transform.parent.Rotate(rotateDirection * speed * Time.fixedDeltaTime);
    }
}
