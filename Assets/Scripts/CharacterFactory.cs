using UnityEngine;
using System.Collections;

public class CharacterFactory : MonoBehaviour
{
    public enum Mob { Rabbit = 0, Bird, Wolf, Bear };
    public enum Boss { Bee = 0 };

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject[] mobPrefabs;

    [SerializeField]
    private GameObject[] bossPrefabs;

    void Start()
    {

    }
}
