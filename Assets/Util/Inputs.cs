using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Inputs : MonoBehaviour
{
    public static UnityEvent<Vector2> onMove = new();
    public static UnityEvent onPickDrop = new();

    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInput.GetUnityEvent("Move").AddListener(OnMove);
        
        //TODO: fix detection
        //playerInput.GetUnityEvent("PickDrop").AddListener(OnPickDrop);
    }

    public void OnPickDrop(InputAction.CallbackContext arg0)
    {
        onPickDrop.Invoke();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        onMove.Invoke(context.ReadValue<Vector2>());
    }
}