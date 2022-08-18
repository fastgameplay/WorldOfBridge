using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private WorldSettingsScriptable worldSettings;
    [SerializeField] private BiomeScriptable[] biomes;
    [Range(0,10)]
    [SerializeField] private float offset;
    [Range(2,4)]
    [SerializeField] private float obsticleWidth;

    //Factory Needed
    [SerializeField] private GameObject startPref;
    [SerializeField] private GameObject roadPref;
    [SerializeField] private GameObject gapPref;
    [SerializeField] private GameObject finishPref;
    private Dictionary<BiomeType, BiomeScriptable> biomeDictionary = new Dictionary<BiomeType, BiomeScriptable>();
    private Dictionary<RoadType, GameObject> roadDictionary = new Dictionary<RoadType, GameObject>();
    //Map
    private MapGenerator mapGenerator;
    private RoadBuilder roadBuilder;
    public Road[] worldMap;
    



    private void Start()
    {
        for (int i = 0; i < biomes.Length; i++){
            biomeDictionary.Add(biomes[i].Type, biomes[i]);
        }
        roadDictionary.Add(RoadType.Start, startPref);
        roadDictionary.Add(RoadType.Road, roadPref);
        roadDictionary.Add(RoadType.Gap, gapPref);
        roadDictionary.Add(RoadType.Finish, finishPref);

        mapGenerator = new MapGenerator(worldSettings);

        roadBuilder = gameObject.AddComponent<RoadBuilder>();

        roadBuilder.SetBuilder(roadDictionary, biomeDictionary);

        worldMap = mapGenerator.GenerateMap(5);

        for (int i = 0; i < worldMap.Length; i++)
        {
            roadBuilder.Build(worldMap[i], transform);
        }

    }

}
