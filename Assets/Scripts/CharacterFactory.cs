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
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        QuestFactory factory = FactoryManager.Instance.QuestFactory;
        QuestFactory.Quest currentQuest = factory.ActiveQuest;

        Transform playerStart = currentQuest.StartQuestPoint;
        Instantiate(playerPrefab, playerStart.position, playerStart.rotation);

        GameObject questObject = currentQuest.QuestEndObject;
        Transform endPoint = currentQuest.EndQuestPoint;
        Instantiate(questObject, endPoint.position, endPoint.rotation);
    }

    public GameObject GetQuestMob(out string mobName)
    {
        int mobRoll = FactoryManager.Instance.QuestFactory.RollDie(mobPrefabs.Length);
        mobName = mobPrefabs[mobRoll].name;
        return mobPrefabs[mobRoll];
    }
}
