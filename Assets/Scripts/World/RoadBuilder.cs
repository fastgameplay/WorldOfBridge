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
    
    public GameObject[] Build(RoadStruct _road,Transform _parent, GameObject _roadPrefab){
        
        GameObject[] obj = new GameObject[0];
        switch (_road.Type)
        {
            case RoadType.Road:
                obj = WithBiome(_road, _roadPrefab, biomeFactory.GetBiome(_road.Biome),_parent);
                break;
            case RoadType.Start:
                WithoutBiome(_road, _roadPrefab, _parent, true);
                break;
            default:
                WithoutBiome(_road,_roadPrefab, _parent,false);
                break;
        }
         return obj;
    }
    private GameObject[] WithBiome(RoadStruct road, GameObject RoadPrefab, BiomeScriptable Biome, Transform parent){
        GameObject holder = new GameObject("RoadHolder");
        holder.transform.position = road.Position;
        holder.transform.rotation = standartQuaternion;
        GameObject RoadObj = Instantiate(RoadPrefab, Vector3.zero, new Quaternion(0,0,0,0), holder.transform);
        RoadObj.AddComponent<Road>().AddStruct(road);
        RoadObj.transform.localPosition = Vector3.zero;
        RoadObj.transform.localScale = road.Scale;
        RoadObj.GetComponent<MeshRenderer>().material.color = Biome.GroundColor;
        holder.transform.parent = parent;
        return Biome.SetBiome(road.Scale, holder.transform);
        
    }
    private GameObject WithoutBiome(RoadStruct road, GameObject RoadPrefab, Transform parent, bool IsColorChanged)
    {
        GameObject obj = Instantiate(RoadPrefab, road.Position, standartQuaternion);
        obj.transform.localScale = road.Scale;
        obj.AddComponent<Road>().AddStruct(road);
        obj.transform.parent = parent;

        if (IsColorChanged) obj.GetComponent<MeshRenderer>().material.color = biomeFactory.GetBiome(road.Biome).GroundColor;

        return obj;
    }

    
}
