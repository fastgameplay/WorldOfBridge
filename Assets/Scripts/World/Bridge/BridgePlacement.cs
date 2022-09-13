using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePlacement : MonoBehaviour{
    public float BridgePercent{
        set{
            if (value < 0) value = 0.0f;
            if (value > 1) value = 1.0f;
            bridgePercent = value;

            UpdatePosition();
            UpdateScale();
        }
    }

    public Vector2 BridgeSize { set {
            if (value.x < 0) value.x = 0;
            if (value.y < 0) value.y = 0;
            bridgeSize2D = value;
        } 
    }

    private Vector3 bridgeVector;
    private Vector3 bridgePos;
    private Vector2 bridgeSize2D;
    private float hight;
    private float bridgePercent;
    
    private float bridgeLength { get { return bridgeVector.magnitude; } }
    public void Place(Vector3 _bridgeVector, float _hight){
        bridgeVector = _bridgeVector;
        hight = _hight;

        bridgePercent = 0;
        BridgeSize = new Vector2(1, 1);

        //Bridge Angle
        transform.localRotation = Quaternion.Euler(new Vector3(0,0, Mathf.Atan2(_bridgeVector.y, _bridgeVector.x) * Mathf.Rad2Deg));
    }
    private void UpdatePosition(){
        bridgePos = bridgeVector * (bridgePercent * 0.5f);
        bridgePos.y += hight;
        transform.localPosition = bridgePos;
    }
    private void UpdateScale(){
        transform.localScale = new Vector3(bridgeLength * bridgePercent, bridgeSize2D.y, bridgeSize2D.x);
    }

}
