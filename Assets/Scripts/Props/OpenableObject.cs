using UnityEngine;
using System.Collections;
using System;

public class OpenableObject : InteractableObject
{
    public enum State { Open, Closed }
    private Animator _animator;

    private State _state = State.Closed;
    public State CurrentState { get { return _state; } }

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact(Character interacter)
    {
        HandleStateChange(interacter);
    }

    private void HandleStateChange(Character interacter)
    {
        switch(_state)
        {
            case State.Closed:
                if (Unlocked(interacter))
                {
                    _animator.SetTrigger("Open");
                    _state = State.Open;
                }
                break;

            case State.Open:
                _animator.SetTrigger("Close");
                _state = State.Closed;
                break;
        }
    }

    protected virtual bool Unlocked(Character interacter)
    {
        return true;
    }
}
