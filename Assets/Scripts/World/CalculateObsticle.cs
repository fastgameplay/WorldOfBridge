
using UnityEngine;

public static class CalculateObsticle
{
    public static Vector3 Position(float angle, float height, float zPos,bool isFlat){
        float x = height * Mathf.Cos(angle / Mathf.Rad2Deg);
        float y = height * Mathf.Sin(angle / Mathf.Rad2Deg);
        if(isFlat) return new Vector3(x, y, 0);
        return new Vector3(x,y, Random.Range(-zPos,zPos));
    }
    
}
