using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkRandom : AutoMonoBehaviour
{
    [Header ("Junk Random")]
    [SerializeField] protected JunkSpawnerControl junkSpawnerControl;
    [SerializeField] protected int maxJunkOnScene = 3;
    [SerializeField] protected float minDurSpawn = 1f;
    [SerializeField] protected float maxDurSpawn = 10f;

    [SerializeField] protected bool canSpawn = true;

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnerControl();
    }
    protected virtual void LoadJunkSpawnerControl()
    {
        if (this.junkSpawnerControl != null) return;
        this.junkSpawnerControl = GetComponent<JunkSpawnerControl>();
        Debug.Log(transform.name + ": Load Junk Spawner", gameObject);
    }
    #endregion LoadComponent

    private void Update()
    {
        RandomSpawn();
    }

    protected virtual void RandomSpawn()
    {

        if (canSpawn == false) return;
        if (this.GetSpawnedCount() >= maxJunkOnScene) return;
        Transform ranTransform = this.junkSpawnerControl.JunkSpawnPoints.GetRanPoint(junkSpawnerControl.JunkSpawnPoints.FrontPoints);
        if (ranTransform == null)
        {
            Debug.LogError(transform.name + "ranTransform is null", gameObject);
            return;
        }
        Vector3 ranSpawnPos = ranTransform.position;
        Quaternion spawnRos = ranTransform.rotation;
        canSpawn = false;
        Transform prefab = this.junkSpawnerControl.JunkSpawner.GetRandomPrefab();
        Transform obj = this.junkSpawnerControl.JunkSpawner.Spawn(prefab, ranSpawnPos, spawnRos);
        StartCoroutine(CooldownSpawn(minDurSpawn, maxDurSpawn));


    }
    protected virtual IEnumerator CooldownSpawn(float minDurSpawn, float maxDurSpawn)
    {
        yield return new WaitForSeconds(minDurSpawn);
        canSpawn = true;

    }
    protected int GetSpawnedCount()
    {
        return this.junkSpawnerControl.JunkSpawner.SpawnedCount;
    }

}
