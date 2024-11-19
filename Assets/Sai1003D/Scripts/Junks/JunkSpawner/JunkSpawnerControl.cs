using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerControl : AutoMonoBehaviour
{

    [SerializeField] protected JunkSpawner junkSpawner;
    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    
    public JunkSpawnPoints JunkSpawnPoints { get => junkSpawnPoints; }
    public JunkSpawner JunkSpawner { get => junkSpawner; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPoints();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        if (this.junkSpawner == null)
            Debug.LogWarning(transform.name + ": Load Junk Spawner Fail", gameObject);
        else
            Debug.Log(transform.name + ": Load Junk Spawner", gameObject);
    }
    protected virtual void LoadJunkSpawnPoints()
    {
        if (this.junkSpawnPoints != null) return;
        this.junkSpawnPoints = GetComponent<JunkSpawnPoints>();
        if (this.junkSpawnPoints == null)
            Debug.LogWarning(transform.name + ": Load Junk Spawn Points Fail", gameObject);
        else
            Debug.Log(transform.name + ": Load Junk Spawn Points", gameObject);

    }
}
