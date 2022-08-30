using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    [SerializeField] private float rotationDelta = 0.025f;
    public float Hight { set { hight = value; } }
    private float hight = 1;



    private float targetRotation;

    private void Update(){

        transform.localEulerAngles = new Vector3(0.0f,0.0f, targetRotation);

    }
    private void LateUpdate(){
        if (targetRotation > 360) targetRotation -= 360;
        if (targetRotation < 0) targetRotation += 360;
    }

    public void AddToTargetRotation(float value){
        value /= hight;
        targetRotation += value;
    }
}
