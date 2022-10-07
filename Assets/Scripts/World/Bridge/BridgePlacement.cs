using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePlacement : MonoBehaviour{
    public Vector3 MaxScale { 
        set {
            maxScale = value;
            startPoint = new Vector3(0, transform.localPosition.y, -value.z);
        } 
    }
    private float BridgePercent{
        get { return bridgePercent; }
        set{
            if (value > 100) value = 100;
            if (value < 0) value = 0;
            bridgePercent = value / 100;

            AdjustPlacement(bridgePercent);
        }
    }
    private float bridgePercent;
    
    private Vector3 maxScale;
    private Vector3 startPoint;

    public void BuildBridge(){
        StartCoroutine(StartBridgeBuilder(100));
    }
    public void BuildBridge(int percent)
    {
        StartCoroutine(StartBridgeBuilder(percent));
    }
    private void AdjustPlacement(float percent){
        transform.localScale = new Vector3(maxScale.x, maxScale.y, maxScale.z * percent);
        transform.localPosition = new Vector3(startPoint.x, startPoint.y, -20 + (maxScale.z * percent)/2);
    }

    private IEnumerator StartBridgeBuilder(int percent){
        for (int i = 1; i <= percent; i++) {
            yield return new WaitForSeconds(0.01f);
            BridgePercent = i;
        }
        if(percent == 100){
            Destroy(GetComponent<BoxCollider>());
        }
    }
}
