using UnityEngine;
using System.Collections;

public class QuestFactory : MonoBehaviour
{
    public enum KeyPoint { Village = 0, Fortress, Moutain, Lake, Forest };

    public class Quest
    {
        public enum Action { Recover = 1, Destroy, Defend, Journey, Gather };
        public enum Object { Item = 1, NPC, Message, Location, Monster };

        public string Name;
        public string Description;
        public Action Verb;
        public Object Noun;
        public GameObject QuestEndObject;

        public Transform[] KeyPoints;
        public Transform StartQuestPoint { get { return KeyPoints[0]; } }
        public Transform EndQuestPoint { get { return KeyPoints[KeyPoints.Length - 1]; } }
    }

    private Quest active;
    public Quest ActiveQuest { get { return active; } }

    private Transform[] keyPoints;

    void Awake()
    {
        GetKeyPoints();
        ChooseActiveQuest();
    }

    private void ChooseActiveQuest()
    {
        int verbRoll = RollDie(6);
        int nounRoll = RollDie(6);
        int startPointRoll = RollDie(5);
        int endPointRoll = RollDie(5);

        // TODO make sure that the start/end location can't be the same
        Quest.Action a = (Quest.Action)verbRoll;
        Quest.Object o = (Quest.Object)nounRoll;
        KeyPoint start = (KeyPoint)(startPointRoll - 1);
        KeyPoint end = (KeyPoint)(endPointRoll - 1);

        GameObject questObj = null;
        string name;
        string customDesc = "";
        switch(o)
        {
            case Quest.Object.Item:
                questObj = FactoryManager.Instance.ItemFactory.GetQuestItem(out name);
                customDesc = string.Format("Find {0}", name); // TODO finish this
                break;

            case Quest.Object.NPC:
                // TODO make NPC prefabs and add them to the character factory with an accessor
                break;

            case Quest.Object.Message:
                // TODO add a message object prefab to the item factory with an accessor
                // this should just be a single object that just has a different message on it
                break;

            case Quest.Object.Location:
                // TODO add a trigger object prefab to the item factory with an accessor
                // this should just be a single object that just has different sizes or something
                break;

            case Quest.Object.Monster:
                questObj = FactoryManager.Instance.CharacterFactory.GetQuestMob(out name);
                customDesc = string.Format("Find {0}", name); // TODO finish this!
                break;
        }

        // TODO add the custom descrption in
        Quest q = new Quest();
        q.Name = string.Format("{0} the {1}!", a.ToString(), o.ToString());
        q.Description = string.Format("Starting here at the {0}, you must travel the land, avoiding enemies and hazards to {1} the {2} at the {3}. Good Luck!",
            start.ToString(), a.ToString(), o.ToString(), end.ToString());
        q.Verb = a;
        q.Noun = o;
        q.KeyPoints = new Transform[2]; // TODO expand this to have intermediate points
        q.KeyPoints[0] = keyPoints[startPointRoll - 1];
        q.KeyPoints[1] = keyPoints[endPointRoll - 1];

        active = q;

        // test
        Debug.Log(q.Name);
        Debug.Log(q.Description);
    }

    private void GetKeyPoints()
    {
        Transform keyPointContainer = FactoryManager.Instance.Level.transform.FindChild("Key Points");
        if (keyPointContainer != null)
        {
            int count = keyPointContainer.childCount;
            keyPoints = new Transform[count];
            for (int i = 0; i < count; ++i)
            {
                keyPoints[i] = keyPointContainer.GetChild(i);
            }
        }
        else
        {
            Debug.LogError("KeyPoint container not found");
        }
    }

    public int RollDie(int sides)
    {
        return UnityEngine.Random.Range(1, sides);
    }
}
