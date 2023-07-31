using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 targetPosition { get; private set; }

    private void Awake()
    {
        targetPosition = Vector2.zero;
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        targetPosition = context.ReadValue<Vector2>();
        Debug.Log(targetPosition);
    }
}
