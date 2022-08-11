using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CubeScaling {
    CubeVariant[] topSettings;
    CubeVariant[] botSettings;
    public CubeScaling(float size){
        topSettings = new CubeVariant[Mathf.FloorToInt(size)];
        botSettings = new CubeVariant[Mathf.FloorToInt(size)];
        topSettings[0] = new CubeVariant(Vector3.zero, Vector3.one);
        botSettings[0] = new CubeVariant(new Vector3(0,-20,0), Vector3.one);
        float SegmentSize = (1 / size);
        for (int i = 1; i < size; i++){
            topSettings[i] = new CubeVariant(new Vector3(0, i * SegmentSize / 2, 0), new Vector3(1, (size - i) * SegmentSize, 1));
            botSettings[i] = new CubeVariant(new Vector3(0, -(size - i) * SegmentSize / 2, 0), new Vector3(1, i * SegmentSize, 1));
        }
    }

    public void SetCubes(GameObject _topObject, GameObject _botObject, int variant)
    {
        if (variant > topSettings.Length) Debug.LogError("SetCubes in CubeScriptableObject OutOfRangeExeption");
        _topObject.transform.localPosition = topSettings[variant].Position;
        _topObject.transform.localScale = topSettings[variant].Scale;

        _botObject.transform.localPosition = botSettings[variant].Position;
        _botObject.transform.localScale = botSettings[variant].Scale;
    }
}
