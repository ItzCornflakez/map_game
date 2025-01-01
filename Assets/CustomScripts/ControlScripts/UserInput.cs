using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    public Vector2 MoveInput { get; private set;}
    public bool AcceptNotificationInput { get; private set;}

    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction acceptNotificationAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Makes this object persist across scenes
            Debug.Log("UserInput instance created and marked persistent.");
        }
        else
        {
            Debug.LogWarning("Duplicate UserInput instance detected. Destroying.");
            Destroy(gameObject);
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
        acceptNotificationAction = playerInput.actions["AcceptNotification"];
    }

    private void UpdateInputs()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        AcceptNotificationInput = acceptNotificationAction.WasPressedThisFrame();
    }
}

