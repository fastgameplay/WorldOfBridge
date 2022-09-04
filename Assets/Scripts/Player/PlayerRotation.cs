using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Range(0, 45)]
    [SerializeField] private float MaxHalfRotationAngle;
    [SerializeField] private Transform PlayerModelTransform;
    public float Hight { set { hight = value; } }
    private float hight = 1;


    public float HorizontalInput { 
        set {
            targetModelAngle = value * MaxHalfRotationAngle;
            AddToTargetRotation(-value);
        } 
    }
    private float targetModelAngle;
    private float targetRotation;

    private void Update(){

        transform.localEulerAngles = new Vector3(0.0f,0.0f, targetRotation);
        PlayerModelTransform.localEulerAngles = new Vector3(0.0f, targetModelAngle, 0.0f);
    }


    private void AddToTargetRotation(float value){
        value /= hight;
        targetRotation += value;
        if (targetRotation > 360) { 
            targetRotation -= 360; 
            return; 
        }
        if (targetRotation < 0) 
            targetRotation += 360; 
    }
}
