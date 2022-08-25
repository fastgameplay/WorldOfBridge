    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float AccelerationRate;
    
    public float TargetSpeed { 
        set {
            if (value < 0) value = 0;
            targetSpeed = value; 
        } 
    }
    private float targetSpeed = 0;
    private float currentSpeed;
    
    
    private void Update(){
        CalculateSpeed();
        if(currentSpeed != 0){
            transform.Translate(Vector3.forward * currentSpeed);
        }
    }

    private void CalculateSpeed(){
        if(Mathf.Abs(targetSpeed - currentSpeed) > AccelerationRate){
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, AccelerationRate);
            return;
        }
        if (currentSpeed == targetSpeed) return;
        currentSpeed = targetSpeed;
        
    }
}
