using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    [SerializeField] protected float isFiring;
    [SerializeField] protected Vector3 worldPos;
    [SerializeField] protected LayerMask layerMaskGround;
    
    public static InputManager Instance { get => instance;}
    public Vector3 WorldPos { get => worldPos;}
    public float IsFiring { get => isFiring;} 
    private void Awake() {
        if (InputManager.instance != null) Debug.LogError("Only 1 Inputmanager exits");
        InputManager.instance = this;
    }
    private void Update() {
        this.GetFire1();
    }
    private void FixedUpdate()  
    {
        this.GetPointFromRay();

    }

    protected virtual void GetPointFromRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMaskGround))
        {
            this.worldPos = hit.point;     
        }

    }

    protected virtual void GetFire1()
    {
        this.isFiring = Input.GetAxis("Fire1");
    }
}
