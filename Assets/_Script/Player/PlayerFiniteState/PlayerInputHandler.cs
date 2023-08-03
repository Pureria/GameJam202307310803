using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] float holdTime = 0.2f;
    public Vector2 targetPosition { get; private set; }
    public bool restartInput { get; private set; }
    public bool titleInput { get; private set; }

    public bool restartCancelInput { get; private set; }
    public bool titleCancelInput { get; private set; }

    private float restartInputTime;
    private float titleInputTime;

    private void Awake()
    {
        targetPosition = Vector2.zero;
    }

    private void Update()
    {
        CheckRestartInput();
        CheckTitleInput();
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        targetPosition = context.ReadValue<Vector2>();
    }

    public void OnRestartInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            restartInput = true;
            restartCancelInput = false;
            restartInputTime = Time.time;
        }

        if(context.canceled)
        {
            restartCancelInput = true;
        }
    }

    public void OnTitleInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            titleInput = true;
            titleCancelInput = false;
            titleInputTime = Time.time;
        }

        if(context.canceled)
        {
            titleCancelInput = true;
        }
    }

    public void UseRestartInput() => restartInput = false;
    public void UseTitleInput() => titleInput = false;

    private void CheckRestartInput()
    {
        if (!restartInput) return;
        if (restartInputTime + holdTime < Time.time)
            restartInput = false;
    }

    private void CheckTitleInput()
    {
        if (!titleInput) return;
        if (titleInputTime + holdTime < Time.time)
            titleInput = false;
    }
}
