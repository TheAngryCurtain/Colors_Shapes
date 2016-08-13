using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // IDEAS
    // pso-style - each level can have different configurations which change up the level each time to you play
    // have a varity of missions all taking place in the sa me level
    //    > Find and speak to NPC, recover specific treasure, kill all enemies, etc
    //    > save character progression and scale difficulty of each randomly chosen mission based on level?
    //    > ... will probably need to make the level bigger...

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
       CharacterFactory factory = CreateCharacterFactory();

        // TODO
        // generate and pick a level configuration
        //    > choose player spawn, then pick enemy spawns and boss spawn
        // instantiate/position player
    }

    private CharacterFactory CreateCharacterFactory()
    {
        GameObject f = new GameObject();
        f.name = "Character Factory";
        return f.AddComponent<CharacterFactory>();
    }
}
