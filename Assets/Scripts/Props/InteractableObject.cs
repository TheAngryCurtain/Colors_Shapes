using UnityEngine;
using System.Collections;
using System;

public abstract class InteractableObject : MonoBehaviour
{
    public Action OnInteractionFinished;

    public abstract void Interact(Character interacter);
}
