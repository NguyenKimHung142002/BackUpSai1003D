using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected float shootDelay = 0.5f;
    protected float shootTime = 0;
    protected bool isShooting;

    void FixedUpdate()
    {
        this.CheckIsShooting();
        this.Shooting();
    }
    protected virtual bool CheckIsShooting()
    {
        return isShooting = InputManager.Instance.IsFiring == 1;
    }
    protected virtual void Shooting()
    {
        if (!isShooting) return;

        //check fire rate
        shootTime += Time.fixedDeltaTime;
        if (shootTime < shootDelay) return;
        shootTime = 0;

        Vector3 spawnPos = transform.parent.position;
        Quaternion spawnRos = transform.parent.rotation;

        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,spawnPos, spawnRos);
        if (newBullet == null) Debug.LogWarning(newBullet + " is Null", gameObject);
    }


}
