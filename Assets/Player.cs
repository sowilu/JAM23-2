using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Movement movement;
    public Health health;

    private void Start()
    {
        Inputs.onMove.AddListener(movement.Move);
    }
}
