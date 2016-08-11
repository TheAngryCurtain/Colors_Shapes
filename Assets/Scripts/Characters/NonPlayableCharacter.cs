using UnityEngine;
using System.Collections;
using System;

public class NonPlayableCharacter : Character
{
    public override int GetKeyCount()
    {
        return _bag.KeyCount;
    }

    public override void Move(float horizontal, float vertical)
    {

    }

    public override void Attack(AttackType type)
    {

    }

    public override void Block()
    {

    }

    public override void Cast()
    {

    }
}
