using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Obsticle", menuName = "ScriptableObjects/Obsticle", order = 3)]
public class ObsticleScriptable : ScriptableObject {
    public GameObject[] Prefabs;
    public int Quantity;

    public float AdditionalHight;
    [Range(0,2)]
    public float RotationSpeed;


    public bool IsMovable;
    public bool IsFlat;
    public GameObject[] Spawn(float xPosition, float distance, Transform parent, float obsticleSize){
        List<GameObject> objects = new List<GameObject>();
        GameObject holder = new GameObject();
        float split = 360 / Quantity;
        for (int i = 0; i < Quantity; i++){
            objects.Add(
                Instantiate(
                    RandomPref(), //prefab
                    CalculateObsticle.Position(i * split, distance + AdditionalHight, obsticleSize, IsFlat), //Position
                    Quaternion.Euler(new Vector3(0, 0, i * split - 90)), //rotation
                    holder.transform
                )
                ); //parent
        }
        holder.transform.parent = parent;
        holder.transform.localPosition = new Vector3(0, xPosition, 0); //Initial Position
        holder.transform.localRotation = Quaternion.Euler( new Vector3(90,  0, Random.Range(0, 360)));//initial Rotation
        if (IsMovable) holder.AddComponent<ObsticleMovement>().RotationSpeed = randomSpeed(RotationSpeed);
        return objects.ToArray();
    }
    
    private GameObject RandomPref(){
        return Prefabs[Random.Range(0, Prefabs.Length)];
    }
    private float randomSpeed(float _speed){
        if (Random.Range(-_speed, _speed) < 0) return -_speed;
        return _speed;
    }

}
