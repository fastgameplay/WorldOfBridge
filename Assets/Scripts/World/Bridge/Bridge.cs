using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private BridgePlacement bridgePlc;
    [Range(0,1)]
    public float bridgePrcent;
    //create child bridge
    //childBridge material get;set;
    public void Create(Vector3 _vector, float _hight){
        GameObject bridgeObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bridgeObj.transform.parent = transform;
        bridgePlc = bridgeObj.AddComponent<BridgePlacement>();
        bridgePlc.Place(_vector, _hight);
        bridgePlc.BridgePercent = 1.0f;
        //TODO couruutine to gradully increace bridgePercent; Or to chane BridgePercent to BridgeTargetPercent and manetain logic there
    }

}
