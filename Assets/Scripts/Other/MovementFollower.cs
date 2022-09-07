using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFollower : MonoBehaviour
{
       [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float smoothSpeed = 0.1f;

    private Vector3 velosity = Vector3.zero;

    private void Update(){
        SmoothMovement();
    }

    private void SmoothMovement(){
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velosity, smoothSpeed);
    }
}
