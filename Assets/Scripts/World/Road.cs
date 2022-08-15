using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public struct Road{
    public float Width;
    public float nextWidth;
    public float Length;
    public float StartPos;
    public float EndPos { get { return StartPos + Length * 2; } }
    public Vector3 Position { get { return new Vector3(0, 0, StartPos + Length); } }
    public Vector3 Scale { get { return new Vector3(Width, Length, Width); } }

    public RoadType Type;

    public BiomeType Biome;


}