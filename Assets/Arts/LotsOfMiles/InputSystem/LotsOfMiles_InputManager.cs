using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class LotsOfMiles_InputManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    IA_LotsOfMiles inputActions;

    void Awake()
    {
        inputActions = new IA_LotsOfMiles();
        inputActions.LotsOfMiles.SingleTouch.started += Touch;
    }

    void OnEnable()
    {
        inputActions?.Enable();
    }

    void OnDisable()
    {
        inputActions?.Disable();
    }

    void Touch(InputAction.CallbackContext context)
    {
    }
}
