using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    [Header ("Junk Spawner")]
    protected static JunkSpawner instance;
    
    protected static string meteoriteOne = "Meteorite1";
    public static JunkSpawner Instance { get => instance; }
    public static string MeteoriteOne { get => meteoriteOne; }


    //khi vao game thi load component lai 1 lan nua va tao singerton
    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null) Debug.LogError("Only 1 Instance at time");
        JunkSpawner.instance = this;
    }
}
