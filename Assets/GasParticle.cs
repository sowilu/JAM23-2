using UnityEngine;

public class GasParticle : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if(other.gameObject.tag == "Player")
      {
         other.gameObject.GetComponent<Health>().maxHp -= 5;
         Destroy(gameObject);
      }
   }
}
