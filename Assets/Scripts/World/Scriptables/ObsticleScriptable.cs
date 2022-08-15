using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Obsticle", menuName = "ScriptableObjects/Obsticle", order = 3)]
public class ObsticleScriptable : ScriptableObject {
    public GameObject[] Prefabs;
    public bool IsMovable;
    public int Quantity;

    public GameObject Spawn(float zPosition, float distance, Transform parent){
        GameObject holder = new GameObject();
        float split = 360 / Quantity;
        for (int i = 0; i <= Quantity; i++){
            Instantiate(RandomPref(), CalculateObsticle.Position(i * split, distance),Quaternion.Euler(new Vector3(0,0,i*split-90)),holder.transform);
        }
        holder.transform.parent = parent;
        holder.transform.localPosition = new Vector3(0, 0, zPosition);
        return holder;
    }
    
    private GameObject RandomPref(){
        return Prefabs[Random.Range(0, Prefabs.Length)];
    }
}
