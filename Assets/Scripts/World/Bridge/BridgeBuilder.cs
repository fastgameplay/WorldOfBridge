using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBuilder{
    public BridgeBuilder(Transform _parent, Color _color, Road _data, float _targetAngle){
        GameObject bridgeHolder = new GameObject("BridgeHolder");
        bridgeHolder.transform.parent = _parent;
        bridgeHolder.transform.localScale = CalculateLocalScale(_parent);
        bridgeHolder.transform.localPosition = Vector3.zero;
        bridgeHolder.transform.localRotation = Quaternion.Euler(0, _targetAngle, 0);

        GameObject bridge = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bridge.transform.parent = bridgeHolder.transform;
        bridge.transform.localRotation = Quaternion.Euler(Vector3.zero);
        bridge.transform.localPosition = Vector3.zero;
        bridge.AddComponent<BridgePlacement>().Place(new Vector3(0,_data.NextWidth- _data.Width, _data.Length * 2),_data.Width) ;
    }    

    private Vector3 CalculateLocalScale(Transform _parent){
        return new Vector3(1 / _parent.transform.localScale.x, 1 / _parent.transform.localScale.y, 1 / _parent.transform.localScale.z);
    }
}