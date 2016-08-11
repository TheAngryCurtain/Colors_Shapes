using UnityEngine;
using System.Collections;
using System;

public class PlayableCharacter : Character
{
    private Vector3 movement;

    public override int GetKeyCount()
    {
        return _bag.KeyCount;
    }

    public void UseKeys(int count)
    {
        _bag.UseKeys(count);
    }

    public override void Move(float horizontal, float vertical)
    {
        movement = (vertical * Camera.main.transform.forward + horizontal * Camera.main.transform.right) * Stats.Speed;
        transform.position = transform.position + new Vector3(movement.x, 0.0f, movement.z) * Time.deltaTime;

        // rotate player
        RotatePlayer(movement * Time.deltaTime);

        //// animate
        //isMoving = (movement != Vector3.zero);
        //if (anim != null)
        //{
        //    anim.SetBool("isMoving", isMoving);
        //}
    }

    public void RotatePlayer(Vector3 direction)
    {
        transform.LookAt(transform.position + new Vector3(direction.x, 0.0f, direction.z));
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
