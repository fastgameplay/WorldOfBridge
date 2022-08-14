using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World Settings", menuName = "ScriptableObjects/WorldSettings", order = 1)]
public class WorldSettingsScriptable : ScriptableObject{
    [Header("Length")]
    [SerializeField] private float minLength;
    [SerializeField] private float maxLength;
    public float GapLength;
    public float Length { get { return Random.Range(minLength, maxLength); } }
    
    [Header("Width")]
    [SerializeField] private float minWidth;
    [SerializeField] private float maxWidth;
    public float Width { get { return Random.Range(minWidth, maxWidth); } }


}
