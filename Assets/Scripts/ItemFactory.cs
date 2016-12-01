using UnityEngine;
using System.Collections;
using System.Linq;

public class ItemFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weaponPrefabs;

    [SerializeField]
    private GameObject[] questItemPrefabs;

    public float[] baseProbabilities = { 0.05f, 0.10f, 0.20f, 0.30f, 0.20f, 0.10f, 0.05f };

    public GameObject GetQuestItem(out string itemName)
    {
        int itemRoll = FactoryManager.Instance.QuestFactory.RollDie(questItemPrefabs.Length);
        itemName = questItemPrefabs[itemRoll].name;
        return questItemPrefabs[itemRoll];
    }

    public GameObject GetDropFromEnemy(int playerLevel, int enemyLevel, int enemyType)
    {
        // TODO need to use player/enemy level and enemy type(name, whatever) to determine which item to return
        float[] cumulativeFunction = GetCumulativeFunction(baseProbabilities);
        float randomValue = UnityEngine.Random.value;
        int itemIndex = GetItemIndex(cumulativeFunction, randomValue);
        return weaponPrefabs[itemIndex];

        //baseProbabilities[tileIndex] = 0.0f;
        //baseProbabilities = NormalizeDensityFunction(baseProbabilities);
    }

    private float[] GetCumulativeFunction(float[] densityFunction)
    {
        int count = densityFunction.Length;
        float[] cumulativeFunction = new float[count];
        float accumulator = 0.0f;
        for (int i = 0; i < count; ++i)
        {
            cumulativeFunction[i] = densityFunction[i] + accumulator;
            accumulator = cumulativeFunction[i];
        }

        return cumulativeFunction;
    }

    private int GetItemIndex(float[] cumulativeFunction, float randomValue)
    {
        for (int i = 0; i < cumulativeFunction.Length; ++i)
        {
            if (cumulativeFunction[i] >= randomValue)
            {
                return i;
            }
        }

        return cumulativeFunction.Length - 1;
    }

    private float[] NormalizeDensityFunction(float[] densityFunction)
    {
        float total = densityFunction.Sum();
        return densityFunction.Select(p => p / total).ToArray();
    }
}
