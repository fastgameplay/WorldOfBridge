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
        if(other.tag == "Bridge"){
            //other.addbridge && player changeHight.
            GameObject obj = CreateEmptyGameObject(other.transform);

            //!TODO ADD ROAD Script TO ROAD GAMEOBJECTS
            //playerHight.TargetHight = other.gameObject.GetComponent<Road>().NextWidth;
        }
    }

    private GameObject CreateEmptyGameObject(Transform parent){
        GameObject gObj = new GameObject();
        gObj.transform.parent = parent.transform;
        gObj.transform.localPosition = Vector3.zero;
        return gObj;
    }
}
