using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float TargetRotation {
        set {
            targetRotation = value;
            if (targetRotation > 360) targetRotation -= 360;
        } 
        get { return targetRotation; } 
    }

    public float Hight;

    [SerializeField] private float rotationDelta = 0.025f;

    [SerializeField] private float playerRotationDelta = 1;

    private Vector3 rotVelosity = Vector3.zero;

    private float targetRotation;
    private float currentRotation { get { return transform.rotation.z; } }

    private void Update(){

        transform.rotation = HolderRotation();
    }
    private Quaternion HolderRotation(){
        return Quaternion.Euler(Vector3.SmoothDamp(new Vector3(0.0f, 0.0f, currentRotation), new Vector3(0.0f, 0.0f, targetRotation), ref rotVelosity, (rotationDelta / Hight)* Time.deltaTime));
    }
}
