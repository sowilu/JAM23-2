using UnityEngine;

[ExecuteAlways]
public class UiFollower : MonoBehaviour
{
   public Vector3 offset = Vector3.up * 2;
   public Transform target;
   
   Camera cam;

   private void Start()
   {
         cam = Camera.main;
   }

   void LateUpdate()
   {
       if (target == null) return;
       
       
        var targetPos = cam.WorldToScreenPoint(target.position + offset)  + offset;
        
        //lerp to target
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10);
    }
}
