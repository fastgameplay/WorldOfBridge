using UnityEngine;
using System;
[Serializable]
public struct RoadStruct
{
    public float Width;
    public float NextWidth;
    public float Length;
    public float StartPos;
    public float EndPos { get { return StartPos + Length * 2; } }
    public Vector3 Position { get { return new Vector3(0, 0, StartPos + Length); } }
    public Vector3 Scale { get { return new Vector3(Width, Length, Width); } }

    public RoadType Type;

    public BiomeType Biome;


}
