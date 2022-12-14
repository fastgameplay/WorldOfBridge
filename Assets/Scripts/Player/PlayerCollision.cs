using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHight))]
[RequireComponent(typeof(PlayerStateManager))]
public class PlayerCollision : MonoBehaviour{
    [SerializeField] private CubeProxy cubeProxy;
    [SerializeField] private SkyBoxManager climateController;
    private PlayerStateManager stateManager;
    private PlayerHight playerHight;

    private void Awake(){
        stateManager = GetComponent<PlayerStateManager>();
        playerHight = GetComponent<PlayerHight>();
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Enemy"){

        }
        if (other.tag == "PickUpCube"){
            cubeProxy.Quantity += other.GetComponent<CubeInfo>().Count;
            Destroy(other.gameObject);
        }
        if (other.tag == "Gap"){
            if(other.transform.childCount == 0){
                if(cubeProxy.Quantity == 0){
                    stateManager.ChangeState(PlayerStateEnum.DEATH);
                }
                new GameObject("TempObject").transform.parent = other.transform;

                Road road = other.gameObject.GetComponent<Road>();

                GameObject bridgeHolder = new GameObject("BridgeHolder");
                bridgeHolder.transform.position = road.Position;
                if(cubeProxy.Quantity < 20){
                    bridgeHolder.AddComponent<BridgeHolder>().BuildBridge(road, transform.localRotation, cubeProxy.Quantity * 5);
                    cubeProxy.DecreaceBy(cubeProxy.Quantity);
                }
                else{
                    bridgeHolder.AddComponent<BridgeHolder>().BuildBridge(road,transform.localRotation,100);
                    cubeProxy.DecreaceBy(20);
                }
            
                playerHight.TargetHight = other.gameObject.GetComponent<Road>().NextWidth/2;
                climateController.ChangeSkyBox(road.Biome);
                stateManager.ChangeState(PlayerStateEnum.BRIDGE);
                Destroy(other.gameObject);
            }
            return;
        }
        if(other.tag == "Bridge"){
            stateManager.ChangeState(PlayerStateEnum.DEATH);
            climateController.StopChanges();


        }
        if(other.tag == "Road"){
            stateManager.ChangeState(PlayerStateEnum.IDLE);


            return;
        }
        Destroy(other);
    }

    private GameObject CreateEmptyGameObject(Transform parent){
        GameObject gObj = new GameObject();
        gObj.transform.parent = parent.transform;
        gObj.transform.localPosition = Vector3.zero;
        return gObj;
    }
}
