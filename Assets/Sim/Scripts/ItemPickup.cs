using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform hands;
    
    Transform itemInHands;

    List<Transform> itemsInRange = new();

    public void PickDrop()
    {
        //if item in hands
        if (itemInHands != null)
        {
            //drop item
            Drop();
        }
        else
        {
            //pick up item
            Pickup();
        }
    }
    
    void Drop()
    {
        //drop item
        itemInHands.SetParent(null);
        
        //find ground beneath item
        RaycastHit hit;
        if (Physics.Raycast(itemInHands.position, Vector3.down, out hit))
        {
            //set item position to ground
            itemInHands.position = hit.point + Vector3.up * 0.5f;
        }
        
        itemInHands = null;
    }

    void Pickup()
    {
        if (itemInHands != null) return;
            //get nearest item
        itemInHands = FindNearest();
        
        if (hands == null)
        {
            //parent on self
            itemInHands.SetParent(transform);
        }
        else
        {
            //parent on hands
            itemInHands.SetParent(hands);
        }
        
        //reset position
        itemInHands.localPosition = Vector3.zero;
    }

    Transform FindNearest()
    {
        Transform nearestItem = null;
        float nearestDistance = float.MaxValue;
        foreach (var item in itemsInRange)
        {
            float distance = Vector3.Distance(transform.position, item.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestItem = item;
            }
        }

        return nearestItem;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemsInRange.Add(other.transform);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemsInRange.Remove(other.transform);
        }
    }
}
