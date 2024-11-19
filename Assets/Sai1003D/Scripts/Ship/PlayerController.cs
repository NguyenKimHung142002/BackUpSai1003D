using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] protected Vector3 targetPos;
   [SerializeField] protected float moveSpeed = 0.1f;

   private void FixedUpdate()
   {
      this.GetTargetPos();
      //this.LookAtMouse();
      this.MovePlayer();
   }

   protected virtual void GetTargetPos()
   {
      this.targetPos = InputManager.Instance.WorldPos;
      this.targetPos.y = 0;
   }
   protected virtual void LookAtMouse()
   {
      Vector3 direction = this.targetPos - transform.parent.position;
      direction.Normalize();

      float rotationY = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
      transform.parent.rotation = Quaternion.Euler(0f, rotationY, 0f);
   }
   protected virtual void MovePlayer()
   {   
      Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, this.moveSpeed * Time.fixedDeltaTime);
      transform.parent.position = newPos;

   }
}
