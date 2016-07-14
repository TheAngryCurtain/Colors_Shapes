using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Bag
{
    [System.Serializable]
    public class Pocket
    {
        public List<Item> Items;

        public Pocket()
        {
            Items = new List<Item>(10);
        }
    }

    [SerializeField]
    private Pocket[] _pockets;

    [SerializeField]
    private float _valuables;
    public float Valuables { get { return _valuables; } }

    public int KeyCount { get { return _pockets[(int)Item.Type.Key].Items.Count; } }

    public Bag()
    {
        int numPockets = System.Enum.GetNames(typeof(Item.Type)).Length;

        _pockets = new Pocket[numPockets];
        for (int i = 0; i < numPockets; ++i)
        {
            _pockets[i] = new Pocket();
        }

        _valuables = 0f;
    }

    public bool AddItem(Item i)
    {
        Pocket pocketToAddTo = GetAppropriatePocket(i);
        if (pocketToAddTo.Items.Count + 1 <= pocketToAddTo.Items.Capacity)
        {
            pocketToAddTo.Items.Add(i);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UseKeys(int count) // TODO change this later to check for key type (chest, door, etc)
    {
        Pocket keyPocket = _pockets[(int)Item.Type.Key];
        for (int i = 0; i < count; ++i)
        {
            keyPocket.Items.RemoveAt(keyPocket.Items.Count - 1);
        }
    }

    private Pocket GetAppropriatePocket(Item i)
    {
        Item.Type itemType = i.Classification;
        return _pockets[(int)itemType];
    }
}
