using UnityEngine;
using System.Collections;

public class BaseInput : MonoBehaviour
{
    public enum Button { BUTTON_A, BUTTON_B, BUTTON_X, BUTTON_Y, L_BUMPER, R_BUMPER, BUTTON_START };

    protected Character character;

    protected virtual void Start()
    {
        character = GetComponent<Character>();
    }

    protected virtual void Update()
    {

    }
}
