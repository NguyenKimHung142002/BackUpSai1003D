using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : AutoMonoBehaviour
{
    [Header ("Spawn Points")]
    [SerializeField] protected List<Transform> lFrontSpawnPoint;
    [SerializeField] protected List<Transform> lRightSpawnPoint;
    [SerializeField] protected List<Transform> lLeftSpawnPoint;
    [SerializeField] protected List<Transform> lBottomSpawnPoint;
    [SerializeField] protected string frontPoints = "FrontPoints";
    [SerializeField] protected string rightPoints = "RightPoints";
    [SerializeField] protected string leftPoints = "LeftPoints";
    [SerializeField] protected string bottomPoints = "BottomPoints";
    public string FrontPoints { get => frontPoints;}
    public string LeftPoints { get => leftPoints;}
    public string RightPoints { get => rightPoints;}
    public string BottomPoints { get => bottomPoints;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFrontPoints();
        this.LoadLeftPoints();
        this.LoadRightPoints();
        this.LoadBottomPoints();
    }

    protected virtual void LoadFrontPoints()
    {
        this.LoadPoints(frontPoints, lFrontSpawnPoint);
    }
    protected virtual void LoadRightPoints()
    {
        this.LoadPoints(rightPoints, lRightSpawnPoint);
    }
    protected virtual void LoadLeftPoints()
    {
        this.LoadPoints(leftPoints, lLeftSpawnPoint);
    }
    protected virtual void LoadBottomPoints()
    {
        this.LoadPoints(bottomPoints, lBottomSpawnPoint);
    }

    protected virtual void LoadPoints(string pointPool, List<Transform> listDirectionPoint)
    {
        if (lFrontSpawnPoint.Count > 0) return;
        Transform pointDirectPool = this.transform.Find("JunkSpawnPoints/"+pointPool);
        if (pointDirectPool == null) return;
        foreach (Transform point in pointDirectPool)
        {
            listDirectionPoint.Add(point);
        }
        Debug.Log(transform.name + ": Load Spawn " + pointPool, gameObject);
    }
    protected virtual List<Transform> GetListPoint(string point)
    {
        if (point == frontPoints) return lFrontSpawnPoint;
        if (point == rightPoints) return lRightSpawnPoint;
        if (point == leftPoints) return lLeftSpawnPoint;
        if (point == bottomPoints) return lBottomSpawnPoint;
        Debug.LogError("Point: " + point + " doesn't exit!");
        return null;
    }
    public virtual Transform GetRanPoint(string pointDirection)
    {
        List<Transform> lPointDirection = GetListPoint(pointDirection);
        int lCout = lPointDirection.Count;
        if (lCout <= 0 ) {
            Debug.LogError(transform.name + ": List of " + pointDirection + ": is Null", gameObject);
            return null;
        }
        int ranPointIndect = Random.Range(0, lCout);
        return lPointDirection[ranPointIndect];
    }
}
