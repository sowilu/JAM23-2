using UnityEngine;

public class Rotator : MonoBehaviour
{
   public Vector3 speed;
   
   void Update()
   {
       transform.Rotate(speed * Time.deltaTime);
   }
}
