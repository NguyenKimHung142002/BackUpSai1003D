using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [Header ("Despawn By Distance")]
    [SerializeField] protected float disLimit = 200f;
    [SerializeField] protected float distance;
    protected override bool CanDespawn()
    {
        
        Vector3 despawnPoint =  DespawnPoint();
        this.distance = Vector3.Distance(transform.parent.position, despawnPoint);
        if (this.distance >= this.disLimit) return true;
        return false;
    }
    // protected virtual Vector3 DespawnPoint()
    // {
    //     Vector3 camPos = GameController.Instance.MainCamera.transform.position;
    //     camPos.y = 0;
    //     return camPos;
    // }
    protected virtual Vector3 DespawnPoint()
    {

        return Vector3.zero;
    }

}
