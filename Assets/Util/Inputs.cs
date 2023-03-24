using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Inputs : MonoBehaviour
{
    public static UnityEvent<Vector2> onMove = new();
    public static UnityEvent onJump = new();

    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInput.GetUnityEvent("Move").AddListener(OnMove);
        playerInput.GetUnityEvent("Jump").AddListener(OnJump);
    }

    private void OnJump(InputAction.CallbackContext arg0)
    {
        onJump.Invoke();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        onMove.Invoke(context.ReadValue<Vector2>());
    }
}