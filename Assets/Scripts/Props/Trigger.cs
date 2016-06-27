using UnityEngine;
using System.Collections;

public enum ButtonType { A }; // Move this to an input class when you have one

public class Trigger : MonoBehaviour
{
    [SerializeField]
    ButtonType _calloutButton;

    [SerializeField]
    InteractableObject _object;

    [SerializeField]
    GameObject _calloutPrefab;

    private GameObject _callout;

    void OnTriggerEnter(Collider collider)
    {
        // TODO instantiate the callout and set it's reference
    }

    void OnTriggerExit(Collider collider)
    {
        // TODO destroy the reference and set callout to null
    }

    // TODO check all of the object triggers to 'is trigger'
    // TODO put trigger on their own layer
    // TODO check for the player collider with that object and make sure this flow works
    // if the player collides with the trigger, get the trigger component and call this function with the button they pressed
    public void InteractWithTrigger(ButtonType button)
    {
        if (button == _calloutButton)
        {
            if (_object != null)
            {
                _object.Interact();
            }
            else
            {
                Debug.LogError("No Object associated with this trigger!");
            }
        }
    }
}
