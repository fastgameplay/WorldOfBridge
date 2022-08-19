using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeFactory : MonoBehaviour
{
    [SerializeField] private BiomeScriptable[] biomes;

    private Dictionary<BiomeType, BiomeScriptable> biomeDictionary = new Dictionary<BiomeType, BiomeScriptable>();

    private void Awake(){
        for (int i = 0; i < biomes.Length; i++){
            biomeDictionary.Add(biomes[i].Type, biomes[i]);
        }   
    }
    public BiomeScriptable GetRandomBiome(){
        return biomes[Random.Range(0, biomes.Length)];
    }
    public BiomeType GetRandomBiomeType()
    {
        return biomes[Random.Range(0, biomes.Length)].Type;
    }
    public BiomeScriptable GetBiome(BiomeType _type){
        return biomeDictionary[_type];
    }
    

}
