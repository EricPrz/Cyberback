using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Controller", menuName = "Controller") ]
public class Controller : ScriptableObject
{
    [SerializeField] private string horizontalAxis;
    [SerializeField] private string verticalAxis;
    [SerializeField] private string jumpButton;
    [SerializeField] private string sprintButton;

    public Vector2 getMovement()
    {
        float horizInput = Input.GetAxis(horizontalAxis);
        float vertInput = Input.GetAxis(verticalAxis);

        return new Vector2(horizInput, vertInput);
    }

    public bool IsJumping()
    {
        return Input.GetButtonDown(jumpButton);
    }
}
