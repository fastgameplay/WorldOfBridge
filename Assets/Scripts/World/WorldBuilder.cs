using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private WorldSettingsScriptable worldSettings;
    [SerializeField] private BiomeScriptable[] biomes;
    [SerializeField] private GameObject startPref;
    [SerializeField] private GameObject roadPref;
    [SerializeField] private GameObject gapPref;
    [SerializeField] private GameObject finishPref;
    private Dictionary<BiomeType, BiomeScriptable> biomeDictionary = new Dictionary<BiomeType, BiomeScriptable>();
    //Map
    private MapGenerator mapGenerator;
    private RoadBuilder roadBuilder;
    public Road[] worldMap;
    



    private void Start()
    {
        for (int i = 0; i < biomes.Length; i++){
            biomeDictionary.Add(biomes[i].Type, biomes[i]);
            Debug.Log(biomes[i].Type == BiomeType.Forest ? $"TypeIsForest And In Dictionary {biomeDictionary[BiomeType.Forest].Type}" : $"BiomeType is not forest but its {biomes[i].Type }");
        }
        
        mapGenerator = new MapGenerator(worldSettings);
        roadBuilder = gameObject.AddComponent<RoadBuilder>();
        roadBuilder.SetBuilder(startPref, roadPref, gapPref, finishPref, biomeDictionary);
        worldMap = mapGenerator.GenerateMap(5);

        for (int i = 0; i < worldMap.Length; i++)
        {
            roadBuilder.Build(worldMap[i], transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
