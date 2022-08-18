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



    public void SetBiome(Vector3 scale, Transform parent) {
        float startPos = (-scale.y)  + Offset;
        float endPos = (scale.y) - Offset;
        scale /= 2;
        Debug.Log("START END POS " + startPos + " : " + endPos);
        float i = startPos;
        while( i < endPos) {
            i += ObsticleSize;
            Obsticles[0].Spawn(i, scale.x, parent, ObsticleSize);
            i += ObsticleSize;
        }

    }

}
