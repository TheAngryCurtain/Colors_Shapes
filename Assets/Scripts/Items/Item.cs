using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public enum Type { Resource = 0, Recovery, Weapon, Shield, Key };

    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }

    [SerializeField]
    private string _desc;
    public string Description { get { return _desc; } }

    [SerializeField]
    private float _worth;
    public float Worth { get { return _worth; } }

    [SerializeField]
    private Type _type;
    public Type Classification { get { return _type; } }

    public Item(string n, string d, float w)
    {
        n = _name;
        d = _desc;
        w = _worth;
    }
}
