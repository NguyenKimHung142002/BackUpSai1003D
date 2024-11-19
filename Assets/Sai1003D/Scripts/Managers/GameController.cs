using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : AutoMonoBehaviour
{
    private static GameController instance;
    [SerializeField] protected GameObject mainCamera;
    
    public static GameController Instance {get => instance;}
    public GameObject MainCamera {get => mainCamera;}
    protected override void Awake() {
        base.Awake();
        if (GameController.instance != null) Debug.LogError("Only 1 GameController exit", gameObject);
        GameController.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (this.mainCamera == null)
            Debug.LogWarning(transform.name + " Load Main Camera Fail", gameObject);
        else
            Debug.Log(transform.name + " Load Main Camera", gameObject);
    }
}
