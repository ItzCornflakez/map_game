using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    public Vector2 MoveInput { get; private set;}
    public bool QuickAcceptEventInput { get; private set;}

    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction quickAcceptEventAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }

    private void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        moveAction = playerInput.actions["Move"];
        quickAcceptEventAction = playerInput.actions["QuickAcceptEvent"];
    }

    private void UpdateInputs()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        QuickAcceptEventInput = quickAcceptEventAction.WasPressedThisFrame();
    }
}

