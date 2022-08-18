using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    
    private Dictionary<RoadType, GameObject> prefs = new Dictionary<RoadType, GameObject>();
    private Dictionary<BiomeType, BiomeScriptable> biomes;

    private Quaternion standartQuaternion;
    public void SetBuilder (Dictionary<RoadType, GameObject> _prefs, Dictionary<BiomeType,BiomeScriptable> _biomes){
        prefs = _prefs;
        biomes = _biomes;
        standartQuaternion = Quaternion.Euler(new Vector3(90, 0, 0));
    }
    
    public GameObject Build(Road road, Transform parent){
        GameObject obj;
        switch (road.Type)
        {
            case RoadType.Road:
                obj = WithBiome(road);
                break;
            default:
                obj = WithoutBiome(road);
                break;
        }
        obj.transform.parent = parent;
        return obj;
    }
    private GameObject WithBiome(Road road){
        GameObject holder = new GameObject("RoadHolder");
        holder.transform.position = road.Position;
        holder.transform.rotation = standartQuaternion;
        GameObject RoadObj = Instantiate(prefs[road.Type], Vector3.zero, new Quaternion(0,0,0,0), holder.transform);
        RoadObj.transform.localPosition = Vector3.zero;
        RoadObj.transform.localScale = road.Scale;
        RoadObj.GetComponent<MeshRenderer>().material.color = biomes[road.Biome].GroundColor;
        biomes[road.Biome].SetBiome(road.StartPos, road.EndPos, road.Scale, holder.transform);
        
        return holder;
        
    }
    private GameObject WithoutBiome(Road road){
        GameObject obj = Instantiate(prefs[road.Type], road.Position, standartQuaternion);
        obj.transform.localScale = road.Scale;
        return obj;
    }

    
}
