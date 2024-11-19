using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dung de tu dong hoa viec reset de tranh bug
public abstract class AutoMonoBehaviour : MonoBehaviour
{
    // thuc hien moi khi reset ben inspector
    protected virtual void Reset() {
        this.LoadComponents();
    }
    protected virtual void Awake() {
        this.LoadComponents();
        this.LoadValue();
    }
    protected virtual void Start() {
        
    }
    protected virtual void LoadComponents()
    {
      //for override
    }
    protected virtual void LoadValue()
    {

    }
}
