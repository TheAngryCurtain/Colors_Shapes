using UnityEngine;
using System.Collections;

public class FactoryManager : MonoBehaviour
{
    public static FactoryManager Instance;

    [SerializeField]
    private GameObject levelObject;
    public GameObject Level { get { return levelObject; } }

    [SerializeField]
    private GameObject[] factoryPrefabs;

    private GameObject[] liveFactories;
    public CharacterFactory CharacterFactory { get { return liveFactories[0].GetComponent<CharacterFactory>(); } }
    public QuestFactory QuestFactory { get { return liveFactories[1].GetComponent<QuestFactory>(); } }
    public ItemFactory ItemFactory { get { return liveFactories[2].GetComponent<ItemFactory>(); } }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CreateFactories();
    }

    private void CreateFactories()
    {
        int count = factoryPrefabs.Length;
        liveFactories = new GameObject[count];
        for (int i = 0; i < count; ++i)
        {
            liveFactories[i] = (GameObject)Instantiate(factoryPrefabs[i], Vector3.zero, Quaternion.identity);
        }
    }
}
