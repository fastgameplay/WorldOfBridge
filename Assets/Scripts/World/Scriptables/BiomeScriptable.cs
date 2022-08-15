using UnityEngine;
[CreateAssetMenu(fileName = "Biome", menuName = "ScriptableObjects/Biome", order = 1)]

public class BiomeScriptable : ScriptableObject {
    public GameObject[] Obsticles;
    public GameObject Coin;
    public Color GroundColor;

    public BiomeType Type;
    public void SetBiome(Vector3 Scale, Transform parent) { 
        
    }
}
