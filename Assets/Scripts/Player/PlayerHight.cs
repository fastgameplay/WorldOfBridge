using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHight : MonoBehaviour{
    [SerializeField] private GameObject PlayerModelHolder;
    [SerializeField] private float HightOffset;
    [SerializeField] private float HightChangeSpeed;
    public float TargetHight
    {
        set
        {
            targetHight = value + HightOffset;
            isHightChange = true;
        }
        get
        {
            return targetHight;
        }
    }
    private float hight
    {
        get
        {
            return PlayerModelHolder.transform.localPosition.y;
        }
        set
        {
            PlayerModelHolder.transform.localPosition = new Vector3(0.0f, value, 0.0f);
        }
    }

    private float targetHight;
    private bool isHightChange = false;

    private void Update(){
        CalculateHight();
    }

    private void CalculateHight()
    {
        if (isHightChange == false) return;

        if (hight > targetHight)
        {
            hight = targetHight;
            isHightChange = false;
        }

        hight = Mathf.MoveTowards(hight, targetHight, HightChangeSpeed);

    }

    public void StopMotion(){
        isHightChange = false;
    }
}
