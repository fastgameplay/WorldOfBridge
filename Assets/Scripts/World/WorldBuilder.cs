using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BiomeFactory))]
public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private WorldSettingsScriptable worldSettings;
    [Range(0,10)]
    [SerializeField] private float offset;
    [Range(2,4)]
    [SerializeField] private float obsticleWidth;

    //Factory Needed
    [SerializeField] private GameObject startPref;
    [SerializeField] private GameObject roadPref;
    [SerializeField] private GameObject gapPref;
    [SerializeField] private GameObject finishPref;
    [SerializeField] private int worldSize;

    [SerializeField] private RoadStruct[] worldMap;
   
    private BiomeFactory biomeFactory;

    private Dictionary<RoadType, GameObject> roadDictionary = new Dictionary<RoadType, GameObject>();
    //Map
    private MapGenerator mapGenerator;
    private RoadBuilder roadBuilder;

    private GameObject[] allObjects;


    private void Start()
    {
        biomeFactory = GetComponent<BiomeFactory>();

        roadDictionary.Add(RoadType.Start, startPref);
        roadDictionary.Add(RoadType.Road, roadPref);
        roadDictionary.Add(RoadType.Gap, gapPref);
        roadDictionary.Add(RoadType.Finish, finishPref);

        mapGenerator = new MapGenerator(worldSettings,biomeFactory);

        roadBuilder = gameObject.AddComponent<RoadBuilder>();

        roadBuilder.SetBuilder(biomeFactory);

        worldMap = mapGenerator.GenerateMap(worldSize);

        List<GameObject> allObstList = new List<GameObject>();

        for (int i = 0; i < worldMap.Length; i++){
              allObstList.AddRange(roadBuilder.Build(worldMap[i], transform, roadDictionary[ worldMap[i].Type]));
        }
        allObjects = allObstList.ToArray();
        Debug.Log("BatchingStarted Objects on scene:" + allObjects.Length );
        StaticBatchingUtility.Combine(allObjects, gameObject);
        Debug.Log("Batching Ended");    
    }

}
