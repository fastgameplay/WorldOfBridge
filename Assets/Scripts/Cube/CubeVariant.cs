using UnityEngine;

[System.Serializable]
public class CubeVariant
{
    public Vector3 Position;
    public Vector3 Scale;


    public CubeVariant(Vector3 _position, Vector3 _scale)
    {
        Position = _position;
        Scale = _scale;
    }
}
