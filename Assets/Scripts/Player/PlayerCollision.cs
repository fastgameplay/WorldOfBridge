using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHight))]
[RequireComponent(typeof(PlayerStateManager))]
public class PlayerCollision : MonoBehaviour{
    private PlayerStateManager stateManager;
    private PlayerHight playerHight;
    private void Awake(){
        stateManager = GetComponent<PlayerStateManager>();
        playerHight = GetComponent<PlayerHight>();
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Gap"){
            if(other.transform.childCount == 0){
                new GameObject("TempObject").transform.parent = other.transform;

                Road road = other.gameObject.GetComponent<Road>();

                GameObject bridgeHolder = new GameObject("BridgeHolder");
                bridgeHolder.transform.position = road.Position;
                bridgeHolder.AddComponent<BridgeHolder>().BuildBridge(road,transform.localRotation);
            
                playerHight.TargetHight = other.gameObject.GetComponent<Road>().NextWidth/2;
            
                stateManager.ChangeState(PlayerStateEnum.BRIDGE);
            
                Destroy(other.gameObject);
            }
        }
        if(other.tag == "Road"){
            stateManager.ChangeState(PlayerStateEnum.IDLE);
            Destroy(other);
        }
    }

    private GameObject CreateEmptyGameObject(Transform parent){
        GameObject gObj = new GameObject();
        gObj.transform.parent = parent.transform;
        gObj.transform.localPosition = Vector3.zero;
        return gObj;
    }
}
