using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollision : MonoBehaviour{
    private PlayerMovement playerMovement;
    private void Awake(){
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Bridge"){
            //other.addbridge && player changeHight.
            GameObject obj = CreateEmptyGameObject(other.transform);
        }
    }

    private GameObject CreateEmptyGameObject(Transform parent){
        GameObject gObj = new GameObject();
        gObj.transform.parent = parent.transform;
        gObj.transform.localPosition = Vector3.zero;
        return gObj;
    }
}
