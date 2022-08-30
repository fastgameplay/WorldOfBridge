using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float TargetRotation {
        set {
            targetRotation = value;

        }
        get { return targetRotation; } 
    }


    [SerializeField] private float rotationDelta = 0.025f;


    private Vector3 rotVelosity = Vector3.zero;

    private float targetRotation;
    private float currentRotation { get { return transform.rotation.z; } }

    private void Update(){


        transform.localEulerAngles = new Vector3(0.0f,0.0f, Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationDelta));

    }
    private void LateUpdate(){
        if (targetRotation > 360) targetRotation -= 360;
        if (targetRotation < 0) targetRotation += 360;
    }

}
