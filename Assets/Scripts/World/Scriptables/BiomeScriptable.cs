using UnityEngine;
[CreateAssetMenu(fileName = "Biome", menuName = "ScriptableObjects/Biome", order = 1)]

public class BiomeScriptable : ScriptableObject {
    public ObsticleScriptable[] Obsticles;
    public GameObject Coin;
    public Color GroundColor;

    public BiomeType Type;
    public void SetBiome(Vector3 scale, Transform parent) {
        scale /= 2;
        Obsticles[0].Spawn(0,scale.x,parent);
    }
}
