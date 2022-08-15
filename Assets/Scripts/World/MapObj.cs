using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapObj
{
    private Road road;
    public MapObj (Road _road){
        road = _road;
    }
    abstract public GameObject build();
}
