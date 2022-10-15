using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeFactory : MonoBehaviour
{
    [SerializeField] private BiomeScriptable[] biomes;

    private Dictionary<BiomeType, BiomeScriptable> biomeDictionary = new Dictionary<BiomeType, BiomeScriptable>();

    private int randPosition = -1;
    private void Awake(){
        for (int i = 0; i < biomes.Length; i++){
            biomeDictionary.Add(biomes[i].Type, biomes[i]);
        }   
    }
    public BiomeScriptable GetRandomBiome(){
        if (randPosition == -1) randPosition = Random.Range(0, biomes.Length);
        randPosition = (randPosition + Random.Range(1, 4)) % biomes.Length;
        return biomes[randPosition];
    }
    public BiomeType GetRandomBiomeType()
    {
        if (randPosition == -1) randPosition = Random.Range(0, biomes.Length);
        randPosition = (randPosition + Random.Range(1, 4)) % biomes.Length;
        return biomes[randPosition].Type;
    }
    public BiomeScriptable GetBiome(BiomeType _type){
        return biomeDictionary[_type];
    }
    

}
