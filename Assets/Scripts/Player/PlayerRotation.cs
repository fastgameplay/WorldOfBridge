using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float TargetDelta {
        set {
            targetDelta = value;
        } 
    }


    [SerializeField] private float smoothSpeed = 1;
    [SerializeField] private float playerRotationDelta = 1;

    private float targetDelta;
    private float currentDelta;
    private float currentRotation { get { return transform.rotation.z; } }

    private void Update(){
        CalculateCurrentDelta();
        if(currentDelta != 0)
            transform.Rotate(0.0f, 0.0f, currentDelta);
    }
    private void CalculateCurrentDelta(){
        currentDelta = Mathf.Lerp(currentDelta, targetDelta, smoothSpeed * Time.deltaTime);
    }
}
