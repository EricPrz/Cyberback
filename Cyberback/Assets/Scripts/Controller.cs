using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[CreateAssetMenu(fileName = "New Controller", menuName = "Controller")]
public class Controller : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private string horizontalAxis;
    [SerializeField] private string verticalAxis;

    [SerializeField] public string suicideButton;
    [SerializeField] private string jumpButton;
    [SerializeField] private string sprintButton;
    [SerializeField] private string shootButton;
    [SerializeField] private string swapWeaponButton;

    [Header("Aim")]
    [SerializeField] private string mouseXInputName;
    [SerializeField] private string mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    public bool IsSuicide()
    {
        return Input.GetButtonDown(suicideButton);
    }

    public bool IsSwapingWeapon()
    {
        return Input.GetButtonDown(swapWeaponButton);
    }

    public bool IsShooting()
    {
        return Input.GetAxis(shootButton) > 0;
    }

    public Vector2 getMovement()
    {
        float horizInput = Input.GetAxis(horizontalAxis);
        float vertInput = Input.GetAxis(verticalAxis);

        return new Vector2(horizInput, vertInput);
    }

    internal bool IsSprinting()
    {
        return Input.GetButton(sprintButton);
    }

    public bool IsJumping()
    {
        return Input.GetButtonDown(jumpButton);
    }

    public float MovementMouseX(float deltaTime)
    {
        return Input.GetAxis(mouseXInputName) * mouseSensitivity * deltaTime;
    }

    public float MovementMouseY(float deltaTime)
    {
        return Input.GetAxis(mouseYInputName) * mouseSensitivity * deltaTime;
    }

    
}
