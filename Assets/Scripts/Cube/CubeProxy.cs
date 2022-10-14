using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeController))]
[RequireComponent(typeof(CubeText))]
public class CubeProxy : MonoBehaviour
{
    //quantity of cube getter
    //SCRIPT FLOW
    //pop text of added quantity
    public int Quantity { 
        get { return cubeController.Quantity; } 
        set {
            if (value < 0) value = 0;
            if (value > maxAmount) value = maxAmount;
            lastQuantity = Quantity;

            cubeController.Quantity = value;

            UpdateCubeText(value);

            popText.Pop(lastQuantity, value);
        }
    }

    [SerializeField] private PopText popText;

    [SerializeField] private int Level;
    [SerializeField] private int blocksPerLevel;
    
    
    private CubeController cubeController;
    private CubeText cubeText;

    private int lastQuantity;
    private int maxAmount;
    
    private void Awake(){
        maxAmount = Level * blocksPerLevel;

        cubeController = GetComponent<CubeController>();
        cubeController.SetUp(Level + 2);

        cubeText = GetComponent<CubeText>();
        cubeText.SetLevel(Level);
        cubeText.SetLevelState(false);
        cubeText.SetMaxState(false);

    }

    private void UpdateCubeText(int _quantity)
    {
        if (_quantity == maxAmount)
        {
            cubeText.SetMaxState(true);
            cubeText.SetText(_quantity.ToString(), Color.red);
        }
        else if (_quantity != maxAmount)
        {
            cubeText.SetMaxState(false);
            cubeText.SetText(_quantity.ToString(), Color.white);
        }
    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Quantity += 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Quantity -= 1;
        }

    }

    public void DecreaceBy(int _amount){
        StartCoroutine(DecreaseCounter(_amount));
    }

    private IEnumerator DecreaseCounter(int _quantity)
    {
        for (int i = 1; i <= _quantity; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Quantity--;
        }
    }
}
