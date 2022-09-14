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
            GameObject obj = CreateEmptyGameObject(other.transform);
            obj.transform.localRotation = Quaternion.Euler(0, 0, transform.localRotation.z);
            obj.AddComponent<Bridge>().Create(new Vector3(road.Length, road.NextWidth - road.Width, 0.0f), road.Width);

            playerHight.TargetHight = other.gameObject.GetComponent<Road>().NextWidth/2;
        }
    }

    private GameObject CreateEmptyGameObject(Transform parent){
        GameObject gObj = new GameObject();
        gObj.transform.parent = parent.transform;
        gObj.transform.localPosition = Vector3.zero;
        return gObj;
    }
}
