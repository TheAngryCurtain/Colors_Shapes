using UnityEngine;
using System.Collections;
using System;

public class UserInput : BaseInput
{
    private float horiontalInput;
    private float verticalInput;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        GetDirectionalInput();
        GetButtonInput();
    }

    private void GetDirectionalInput()
    {
        horiontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        character.Move(horiontalInput, verticalInput);
    }

    private void GetButtonInput()
    {
        if (IsPressed(Button.BUTTON_A)) character.Attack(Character.AttackType.LIGHT);
        if (IsPressed(Button.BUTTON_B)) character.Block();
        if (IsPressed(Button.BUTTON_X)) character.Attack(Character.AttackType.HEAVY);
        if (IsPressed(Button.BUTTON_Y)) character.Cast();
        //if (IsPressed(Button.BUTTON_START)) GameManager.Instance.Pause();
    }

    private bool IsPressed(Button b)
    {
        switch (b)
        {
            case Button.BUTTON_A:
                return Input.GetButtonDown("A");

            case Button.BUTTON_B:
                return Input.GetButtonDown("B");

            case Button.BUTTON_X:
                return Input.GetButtonDown("X");

            case Button.BUTTON_Y:
                return Input.GetButtonDown("Y");

            //case Button.L_BUMPER:
            //    return Input.GetButtonDown(inputStrings[(int)InputType.DODGE]);

            //case Button.R_BUMPER:
            //    return Input.GetButtonDown(inputStrings[(int)InputType.BLIND]);

            case Button.BUTTON_START:
                return Input.GetButtonDown("Pause");

            default:
                return false;
        }
    }
}
