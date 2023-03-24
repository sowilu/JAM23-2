using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ItemPickup itemPickup;
    public Movement movement;
    public Health health;

    private void Start()
    {
        Inputs.onMove.AddListener(movement.Move);
        Inputs.onPickDrop.AddListener(itemPickup.PickDrop);
    }
}
