using UnityEngine;
[CreateAssetMenu(fileName = "Biome", menuName = "ScriptableObjects/Biome", order = 1)]

public class BiomeScriptable : ScriptableObject {

    public BiomeType Type { get { return type; } }
    [SerializeField] private BiomeType type;

    public Color GroundColor { get { return GroundColor; } }
    [SerializeField] private Color groundColor;
    
    [SerializeField] private ObsticleScriptable[] Obsticles;
    [SerializeField] private GameObject Coin;
    [Range(1,5)]
    [SerializeField] private float Offset;
    [Range(1,2.5f)]
    [SerializeField] private float ObsticleSize;



    public void SetBiome(float minPosition, float maxPosition,Vector3 scale, Transform parent) {
        scale /= 2;
        for (float i = minPosition + Offset; i < maxPosition - Offset; i+= ObsticleSize){
            Obsticles[0].Spawn(i, scale.x, parent, ObsticleSize);
        }
    }

}
