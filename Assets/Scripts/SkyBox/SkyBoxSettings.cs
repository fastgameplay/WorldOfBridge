using UnityEngine;

[CreateAssetMenu(fileName = "SkyBoxSetting", menuName = "ScriptableObjects/SpawnSkyBoxSettings")]
public class SkyBoxSettings : ScriptableObject{
    public Color TopColor;
    public Color BotColor;
    public bool IsDay;
    public bool IsStarsVisible;
}
