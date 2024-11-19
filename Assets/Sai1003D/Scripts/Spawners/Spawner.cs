using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class dung de thuc hien nhiem vu spawn
public abstract class  Spawner : AutoMonoBehaviour
{
    [Header ("Abstract Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> lPrefabs;
    [SerializeField] protected List<Transform> lPoolHolder;
    [SerializeField] protected int spawnedCount = 0;
    [SerializeField] protected float addPoolDelay = 0f;
    public int SpawnedCount {get => spawnedCount;} 
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    // day tat ca nhung obj ben trong prefab vao trong list
    protected virtual void LoadPrefabs()
    {
        if (this.lPrefabs.Count > 0) return;
        Transform prefabGObj = transform.Find("Prefabs");
        foreach(Transform obj in prefabGObj)
        {
            this.lPrefabs.Add(obj);
        }
        this.HidePrefabs();

        if (lPrefabs.Count == 0) Debug.LogWarning(transform.name + ": LoadPrefabs count 0", gameObject);
        else Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        this.holder = transform.Find("Holder");
        if (holder == null)
            Debug.LogWarning(transform.name + ": Holder Fail", gameObject);
        else
            Debug.Log(transform.name + ": Holder", gameObject);
    }
    //set active fall cho prefab ben trong list
    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in lPrefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    //spawn by string
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion spawnRos)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null) {
            Debug.LogWarning("prefab: " + prefabName + " Not Found");
            return null;
        }
        return Spawn(prefab, spawnPos, spawnRos);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion spawnRos)
    {
        Transform newPrefab = this.GetObjectFromHolder(prefab);
        spawnedCount++;
        newPrefab.SetPositionAndRotation(spawnPos, spawnRos);
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }
    // moi khi game obj can despawn thi thay vi destroy no t se luu no vao poolHolder 
    // de khi nao can thi se lay ra su dung tiep, tranh instantiate
    public virtual void DeSpawn(Transform prefab)
    {
        
        prefab.gameObject.SetActive (false);
        spawnedCount--;
       
        StartCoroutine(AddPoolDelay());
        lPoolHolder.Add(prefab);
        
    }
    protected virtual IEnumerator AddPoolDelay()
    {
        yield return new WaitForSeconds(addPoolDelay);
    }
    //truoc het thi se lay dan du tru nam trong holder roi moi tinh tao dan moi sau
    protected virtual Transform GetObjectFromHolder(Transform prefab)
    {
        //neu prefab can lay nam trong holder thi se xoa torng folder do va lay prefab ra
        foreach(Transform obj in lPoolHolder)
        {
            if (obj.name == prefab.name)
            {
                this.lPoolHolder.Remove(obj);
                return obj;
            }
        }
        // neu khong co trong holder thi se tao moi prefab
        Transform newPrefab = Instantiate(prefab, holder);
        //tranh viec newPrefab name co ten clone
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    //get random prefab in list
    public virtual Transform GetRandomPrefab()
    {
        int i = Random.Range(0, this.lPrefabs.Count);
        return this.lPrefabs[i];
    }
    //khi spawn thi se lay prefab dua theo ten prefab
     
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in lPrefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        if (lPrefabs != null) return lPrefabs[0];
        return null;
    }

    public virtual Transform GetPrefabByParentName(string prefabName)
    {
        foreach (Transform prefab in lPrefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        if (lPrefabs != null) return lPrefabs[0];
        return null;
    }

}
