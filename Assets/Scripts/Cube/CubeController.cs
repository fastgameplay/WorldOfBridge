using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public CubeScriptableObject CubeVariator;
    [SerializeField] private GameObject cubePref;
    [SerializeField] private Color[] colors;
    [SerializeField] private Color baseColor;
    const int sectionsAmount = 4;
    //TextController
    private Material topMaterial;
    private Material botMaterial;
    private GameObject topObject;
    private GameObject botObject;

    private int quantity;

    public int Quantity{
        get { return quantity; }
        set { 
            quantity = value;
            SetColors();
            SetTransform();
        }
    }



    void Start()
    {
        quantity = 0;
        topObject = Instantiate(cubePref, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
        botObject = Instantiate(cubePref, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
        topMaterial = topObject.GetComponent<Material>();
        botMaterial = botObject.GetComponent<Material>();
        topObject.transform.localPosition = Vector3.zero;
        botObject.transform.localPosition = new Vector3(0, -20, 0);

    }

    private void plus(int _amount){
        

        quantity += _amount;
        SetColors();
        SetTransform();
    }

    private void SetColors(){
        topMaterial.color = colors[(quantity / sectionsAmount -1) % colors.Length]; //if quantity == 0 colors id = colors.length-1 (LastID)
        botMaterial.color = colors[quantity / sectionsAmount % colors.Length]; //if quantity == 0 colors id = 0
    }


    private void SetTransform(){
        CubeVariator.SetCubes(topObject, botObject, quantity % sectionsAmount);
    }
}

