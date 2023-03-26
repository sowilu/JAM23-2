using System;
using System.Collections;
using UnityEngine;

public abstract  class Item : MonoBehaviour
{
    public virtual void Activate()
    {
        
    }
}

public class Gas : Item
{
    public GameObject gasPrefab;
    
    
    public override  void Activate()
    {
        StartCoroutine(GasRoutine());
    }

    IEnumerator GasRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(gasPrefab, transform.position, Quaternion.identity);
        }
    }
}
