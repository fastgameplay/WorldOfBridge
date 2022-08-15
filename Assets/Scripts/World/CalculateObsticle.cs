
using UnityEngine;

public static class CalculateObsticle
{
    public static Vector3 Position(float angle, float distance){
        float x = distance * Mathf.Cos(angle / Mathf.Rad2Deg);
        float y = distance * Mathf.Sin(angle / Mathf.Rad2Deg);
        return new Vector3(x,y,0);
    }
    
}
