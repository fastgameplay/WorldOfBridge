using UnityEngine;
using System;
[Serializable]
public class Road : MonoBehaviour {
    
    public float Width { get { return rs.Width; } }
    public float NextWidth { get { return rs.NextWidth; } }
    public float Length { get { return rs.Length; } }
    public float StartPos { get{ return rs.StartPos; } }
    public float EndPos { get { return rs.StartPos + rs.Length * 2; } }
    public Vector3 Position { get { return new Vector3(0, 0, rs.StartPos + rs.Length); } }
    public Vector3 Scale { get { return new Vector3(rs.Width, rs.Length, rs.Width); } }
    public RoadType Type { get { return rs.Type; } }
    public BiomeType Biome { get { return rs.Biome; } }

    private RoadStruct rs;

    public void AddStruct (RoadStruct _rs){
        rs = _rs;
    }

}