using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationEvent : MonoBehaviour
{
    public void DestroyParent(){
        Destroy(transform.parent.gameObject);
    }
}
