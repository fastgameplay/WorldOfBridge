using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySettingsFactory : MonoBehaviour
{
    [SerializeField] private SkyBoxSettings[] SkyBoxSettings;

    public SkyBoxSettings GetSkyBoxOfType(BiomeType type){
        List<SkyBoxSettings> tempList = new List<SkyBoxSettings>();
        for (int i = 0; i < SkyBoxSettings.Length; i++){
            if(SkyBoxSettings[i].BiomeType == type)
                tempList.Add(SkyBoxSettings[i]);
        }
        
        if (tempList.Count != 0) return tempList[Random.Range(0, tempList.Count)];

        Debug.LogWarning("There is no SkyBoxSettings of type" + type);
        return SkyBoxSettings[Random.Range(0, SkyBoxSettings.Length)];
    }
}
