using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;



public class FxSpawner : Spawner
{
    [Header ("FX Spawner")]
    protected static FxSpawner instance;
    public static FxSpawner Instance { get => instance; }

    //khi vao game thi load component lai 1 lan nua va tao singerton
    protected override void Awake()
    {
        base.Awake();
        if (FxSpawner.instance != null) Debug.LogError("Only 1 Instance at time");
        FxSpawner.instance = this;
    }
}
