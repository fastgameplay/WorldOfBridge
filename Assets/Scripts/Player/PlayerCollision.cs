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
            Road road = other.gameObject.GetComponent<Road>();
            
            playerHight.TargetHight = other.gameObject.GetComponent<Road>().NextWidth/2;
            
            stateManager.ChangeState(PlayerStateEnum.BRIDGE);
            
            Destroy(other);
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
