using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    BiomeFactory biomeFactory;

    private Quaternion standartQuaternion;
    public void SetBuilder (BiomeFactory _biomeFactory){
        biomeFactory = _biomeFactory;
        standartQuaternion = Quaternion.Euler(new Vector3(90, 0, 0));
    }
    
    public GameObject Build(RoadStruct _road,Transform _parent, GameObject _roadPrefab)
    {
        GameObject obj;
        switch (_road.Type)
        {
            case RoadType.Road:
                obj = WithBiome(_road, _roadPrefab, biomeFactory.GetBiome(_road.Biome));
                break;
            default:
                obj = WithoutBiome(_road,_roadPrefab);
                break;
        }
        obj.transform.parent = _parent;
        return obj;
    }
    private GameObject WithBiome(RoadStruct road, GameObject RoadPrefab, BiomeScriptable Biome){
        GameObject holder = new GameObject("RoadHolder");
        holder.transform.position = road.Position;
        holder.transform.rotation = standartQuaternion;
        GameObject RoadObj = Instantiate(RoadPrefab, Vector3.zero, new Quaternion(0,0,0,0), holder.transform);
        RoadObj.AddComponent<Road>().AddStruct(road);
        RoadObj.transform.localPosition = Vector3.zero;
        RoadObj.transform.localScale = road.Scale;
        RoadObj.GetComponent<MeshRenderer>().material.color = Biome.GroundColor;
        Biome.SetBiome(road.Scale, holder.transform);
        
        return holder;
        
    }
    private GameObject WithoutBiome(RoadStruct road, GameObject RoadPrefab)
    {
        GameObject obj = Instantiate(RoadPrefab, road.Position, standartQuaternion);
        obj.transform.localScale = road.Scale;
        obj.AddComponent<Road>().AddStruct(road);
        return obj;
    }

    
}
