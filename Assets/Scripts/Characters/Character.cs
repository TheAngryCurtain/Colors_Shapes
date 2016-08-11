using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    public enum AttackType { LIGHT, MEDIUM, HEAVY };

    [System.Serializable]
    public class BaseStats
    {
        public float Speed;
        public float Attack;
        public float Defense;
        public float Magic;
    }

    [SerializeField]
    protected BaseStats Stats;

    [SerializeField]
    protected Bag _bag;
    public Bag Bag { get { return _bag; } }

    public float GetValuablesCount { get { return _bag.Valuables; } }

    public abstract int GetKeyCount();
    public abstract void Move(float h, float v);
    public abstract void Attack(AttackType type);
    public abstract void Block();
    public abstract void Cast();
}
