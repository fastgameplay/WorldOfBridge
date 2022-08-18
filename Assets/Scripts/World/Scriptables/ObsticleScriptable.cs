using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Obsticle", menuName = "ScriptableObjects/Obsticle", order = 3)]
public class ObsticleScriptable : ScriptableObject {
    public GameObject[] Prefabs;
    public int Quantity;
    
    public bool IsMovable;
    [Range(0,2)]
    public float RotationSpeed;
    public GameObject Spawn(float xPosition, float distance, Transform parent, float obsticleSize){
        GameObject holder = new GameObject();
        float split = 360 / Quantity;
        for (int i = 0; i <= Quantity; i++){
            Instantiate(
                RandomPref(), //prefab
                CalculateObsticle.Position(i * split, distance, obsticleSize), //Position
                Quaternion.Euler(new Vector3(0,0,i*split-90)), //rotation
                holder.transform); //parent
        }
        holder.transform.parent = parent;
        holder.transform.localPosition = new Vector3(0, xPosition, 0);
        if (IsMovable) holder.AddComponent<ObsticleMovement>().SetUp(randomSpeed(RotationSpeed));
        return holder;
    }
    
    private GameObject RandomPref(){
        return Prefabs[Random.Range(0, Prefabs.Length)];
    }
    private float randomSpeed(float _speed){
        if (Random.Range(-_speed, _speed) < 0) return -_speed;
        return _speed;
    }

}
