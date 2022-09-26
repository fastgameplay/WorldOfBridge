using UnityEngine;

public class BridgeHolder : MonoBehaviour{
    public void BuildBridge(Road _road, Quaternion _bridgeRotation){

        GameObject bridge = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bridge.transform.parent = transform;
        bridge.transform.localPosition = new Vector3(0,_road.Width/2-0.5f,0);
        transform.rotation = _bridgeRotation;
        BridgePlacement bp = bridge.AddComponent<BridgePlacement>();
        bp.MaxScale = new Vector3(1, 1, _road.Length * 2);
        bp.BuildBridge();
    }

}
