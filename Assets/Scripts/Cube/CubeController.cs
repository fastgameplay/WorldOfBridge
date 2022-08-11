using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public CubeScaling CubeVariator;
    [SerializeField] private GameObject cubePref;
    [SerializeField] private Color[] colors;
    [SerializeField] private Color baseColor;

    public int TempQuantity;

    public int sectionsAmount = 5;
    //TextController
    private Material topMaterial;
    private Material botMaterial;
    private GameObject topObject;
    private GameObject botObject;

    private int quantity;

    [SerializeField]
    public int Quantity{
        get { return quantity; }
        set { 
            quantity = value;
            if (quantity < 0) quantity = 0;
                SetColors();
            SetTransform();
        }
    }



    void Start()
    {
        CubeVariator = new CubeScaling(sectionsAmount);
        quantity = 0;
        TempQuantity = 0;
        topObject = Instantiate(cubePref, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
        botObject = Instantiate(cubePref, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
        topMaterial = topObject.GetComponent<MeshRenderer>().material;
        botMaterial = botObject.GetComponent<MeshRenderer>().material;
        topObject.transform.localPosition = Vector3.zero;
        botObject.transform.localPosition = new Vector3(0, -20, 0);

    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Quantity += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Quantity -= 1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Quantity += 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Quantity -= 1;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            CubeVariator = new CubeScaling(sectionsAmount);
        }
    }
    private void plus(int _amount){
        

        quantity += _amount;
        SetColors();
        SetTransform();
    }

    private void SetColors(){
        if (quantity < sectionsAmount){
            topMaterial.color = Color.white;
            botMaterial.color = colors[1];
        }
        else{
            topMaterial.color = colors[(quantity / sectionsAmount) % colors.Length];
            botMaterial.color = colors[(quantity / sectionsAmount + 1) % colors.Length];
        }

    }


    private void SetTransform(){
        CubeVariator.SetCubes(topObject, botObject, quantity % sectionsAmount);
    }
}

