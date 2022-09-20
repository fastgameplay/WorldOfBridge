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

        BridgeSize = new Vector2(1, 0.1f);

        //Bridge Angle
        transform.localRotation = Quaternion.Euler(new Vector3((Mathf.Atan2( _bridgeVector.y, _bridgeVector.z)*Mathf.Rad2Deg) * -1, 0, 0));

        BridgePercent = 1;
    }
    private void UpdatePosition(){

        transform.localPosition = new Vector3(0,0, -bridgeVector.y/2);
    }
    private void UpdateScale(){
        transform.localScale = new Vector3(bridgeSize2D.x, bridgeLength * bridgePercent, bridgeSize2D.y);
    }

}
