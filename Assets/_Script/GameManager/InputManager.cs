using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMonoBehaviour
{
    public static InputManager Instance => SingletonMonoBehaviour.Instance as InputManager;
    [SerializeField] PlayerInputHandler playerInput;

    public PlayerInputHandler GetPlayerInput() { return playerInput; }
}
