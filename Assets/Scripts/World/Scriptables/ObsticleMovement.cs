using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleMovement : MonoBehaviour
{
    private float rotationSpeed;
    public void SetUp(float _rotationSpeed){
        rotationSpeed = _rotationSpeed;
    }
    void Update(){
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
