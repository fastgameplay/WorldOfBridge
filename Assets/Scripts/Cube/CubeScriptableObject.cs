using UnityEngine;
[CreateAssetMenu(fileName = "CubeSettings", menuName = "ScriptableObjects/CounterCube Settings", order = 1)]
public class CubeScriptableObject : ScriptableObject{
    public CubeVariant[] topSettings;
    public CubeVariant[] botSettings;
    
    public void SetCubes(GameObject _topObject, GameObject _botObject, int variant){
        if (variant > topSettings.Length) Debug.LogError("SetCubes in CubeScriptableObject OutOfRangeExeption");
        _topObject.transform.localPosition = topSettings[variant].Position;
        _topObject.transform.localScale = topSettings[variant].Scale;

        _botObject.transform.localPosition = botSettings[variant].Position;
        _botObject.transform.localScale = botSettings[variant].Scale;
    }
}
