using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHight))]
public class PlayerCollision : MonoBehaviour{

    private PlayerHight playerHight;
    private void Awake(){
        playerHight = GetComponent<PlayerHight>();
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Gap"){
            Road road = other.gameObject.GetComponent<Road>();
            
            if (other.transform.childCount == 0){
                BridgeBuilder bb = new BridgeBuilder(other.transform, Color.green, road, transform.rotation.eulerAngles.z);
            }

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
