using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeInfo))]
[RequireComponent(typeof(CubeText))]
public class PickupCubeRandomizer : MonoBehaviour{
    [SerializeField] int MaxCount;
    private void Start(){
        int cubeCount = Random.Range(0, MaxCount);
        GetComponent<CubeInfo>().Count = cubeCount;
        CubeText cubeText = GetComponent<CubeText>();

        cubeText.SetLevelState(false);
        cubeText.SetMaxState(false);

        cubeText.SetText(cubeCount.ToString(), Color.green);
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        Destroy(this);
    }
}
