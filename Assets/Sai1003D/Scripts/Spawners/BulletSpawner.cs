using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum BulletType {
    [Description("Missle")]
    Missile
}

public class BulletSpawner : Spawner
{
    [Header ("Bullet Spawner")]
    protected static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }
    public static string bulletOne = "Missile";
    public BulletType eBulletType;

    //khi vao game thi load component lai 1 lan nua va tao singerton
    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("Only 1 Instance at time");
        BulletSpawner.instance = this;
    }
}
