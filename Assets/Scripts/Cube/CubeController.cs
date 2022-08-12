using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CubeController : MonoBehaviour
{
    public CubeScaling CubeVariator;
    [SerializeField] private GameObject cubePref;
    [SerializeField] private Color[] colors;
    [SerializeField] private Color baseColor;
    [Range(1,8)]
    [SerializeField] private int level;
    [SerializeField] private int blocksPerLevel;
    private int sectionsAmount;
    private int maxAmount;

    [Header("Texts")]
    [SerializeField] TextMeshPro counterText;
    [SerializeField] TextMeshPro levelText;
    [SerializeField] TextMeshPro maxText;
    bool isMaxAmount;
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
            if (quantity > maxAmount) quantity = maxAmount;
            
            SetColors();
            SetTransform();
            UpdateText();
        }
    }



    void Start()
    {
        levelText.text = $"LVL {level}";
        maxText.gameObject.SetActive(false);
        maxAmount = level * blocksPerLevel;
        sectionsAmount = level + 2;
        CubeVariator = new CubeScaling(sectionsAmount);
        quantity = 0;
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
            level += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            level -= 1;
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
            levelText.text = $"LVL {level}";
            maxAmount = level * blocksPerLevel;
            if (quantity > maxAmount) quantity = maxAmount;
            sectionsAmount = level + 2;
            UpdateText();
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

    private void UpdateText(){
        counterText.text = quantity.ToString();
        if(quantity == maxAmount && !isMaxAmount){
            isMaxAmount = true;
            maxText.gameObject.SetActive(true);
            counterText.color = Color.red;
            levelText.color = Color.red;
        }
        else if (quantity != maxAmount && isMaxAmount){
            isMaxAmount = false;
            maxText.gameObject.SetActive(false);
            counterText.color = Color.white;
            levelText.color = Color.green;

        }
    }
}

