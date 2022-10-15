using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Biome", menuName = "ScriptableObjects/Biome", order = 1)]

public class BiomeScriptable : ScriptableObject {

    public BiomeType Type;

    public Color GroundColor;
    
    [SerializeField] private ObsticleScriptable[] Obsticles;
    [SerializeField] private GameObject Coin;
    [Range(0,5)]
    [SerializeField] private float Offset;
    [Range(0,2.5f)]
    [SerializeField] private float ObsticleSize;



    public GameObject[] SetBiome(Vector3 scale, Transform parent) {
        List<GameObject> BiomeObjects = new List<GameObject>();
        float startPos = (-scale.y)  + Offset;
        float endPos = (scale.y) - Offset;
        scale /= 2;
        float i = startPos;
        while( i < endPos) {
            BiomeObjects.AddRange(Obsticles[Random.Range(0,Obsticles.Length)].Spawn(i, scale.x, parent, ObsticleSize) );
            i += ObsticleSize*2;
        }
        return BiomeObjects.ToArray();
    }

}
