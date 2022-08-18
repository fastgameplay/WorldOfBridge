
using UnityEngine;

public static class CalculateObsticle
{
    public static Vector3 Position(float angle, float height, float zPos){
        float x = height * Mathf.Cos(angle / Mathf.Rad2Deg);
        float y = height * Mathf.Sin(angle / Mathf.Rad2Deg);
        return new Vector3(x,y, Random.Range(-zPos,zPos));
    }
    
}
