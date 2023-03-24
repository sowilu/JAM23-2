using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if item
        if (other.gameObject.CompareTag("Item"))
        {
            //wait for 3 seconds
            StartCoroutine(WaitForItem(other));
        }
    }

    private IEnumerator WaitForItem(Collider other)
    {

            yield return new WaitForSeconds(3);

            if (other != null)
            {
                //get item component
                            var item = other.gameObject.GetComponent<Item>();
                            
                            //check mutation type
                            if (item.mutation == Mutation.Health)
                            {
                                //mutate health
                                Mutator.inst.Mutate(item.hpBoost, item.maxHpBoost);
                            }
                            
                            Destroy(other.gameObject);
            }
    }
}
