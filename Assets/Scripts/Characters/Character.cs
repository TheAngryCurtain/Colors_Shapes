using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    // TODO base character for player and enemies

    [SerializeField]
    private Bag _bag;

    public float GetValuablesCount { get { return _bag.Valuables; } }
    public int GetKeyCount { get { return _bag.KeyCount; } }

    public void UseKeys(int count)
    {
        _bag.UseKeys(count);
    }
}
