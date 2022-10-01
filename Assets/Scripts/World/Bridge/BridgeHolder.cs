using UnityEngine;

public class BridgeHolder : MonoBehaviour{
    public void BuildBridge(Road _road, Quaternion _bridgeRotation){

        GameObject bridge = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bridge.transform.parent = transform;
        bridge.transform.localPosition = new Vector3(0,_road.Width/2-0.5f,0);
        bridge.tag = "Bridge";
        transform.rotation = _bridgeRotation;
        BoxCollider col = bridge.GetComponent<BoxCollider>();
        col.isTrigger = true;
        col.center = new Vector3(0, 0, 0.8f);
        col.size = new Vector3(5, 5, 0.63f);
        BridgePlacement bp = bridge.AddComponent<BridgePlacement>();
        bp.MaxScale = new Vector3(1, 1, _road.Length * 2);
        bp.BuildBridge();
    }
    public void BuildBridge(Road _road, Quaternion _bridgeRotation, int percent)
    {

        GameObject bridge = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bridge.transform.parent = transform;
        bridge.transform.localPosition = new Vector3(0, _road.Width / 2 - 0.5f, 0);
        bridge.tag = "Bridge";
        transform.rotation = _bridgeRotation;
        BoxCollider col = bridge.GetComponent<BoxCollider>();
        col.isTrigger = true;
        col.center = new Vector3(0, 0, 0.8f);
        col.size = new Vector3(5, 5, 0.63f);
        BridgePlacement bp = bridge.AddComponent<BridgePlacement>();
        bp.MaxScale = new Vector3(1, 1, _road.Length * 2);
        bp.BuildBridge(percent);
    }
}
