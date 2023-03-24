using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public static class Extensions
{
    public static Vector3 X0Y(this Vector2 v)
    {
        return new Vector3(v.x, 0, v.y);
    }

    public static Vector2 XZ(this Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }
    
    public static PlayerInput.ActionEvent GetUnityEvent(this PlayerInput playerInput, string actionName)
    {
        if (playerInput == null || string.IsNullOrEmpty(actionName)) return null;

        InputAction action = playerInput.actions.FindAction(actionName);

        if (action == null)
        {
            Debug.LogError($"No action found with the name '{actionName}'.");
            return null;
        }

        foreach (var binding in playerInput.actionEvents)
        {
            if (binding.actionId == action.id.ToString())
            {
                return binding;
            }
        }

        Debug.LogError("Action with id not found in action events.");
        return null;
    }

}