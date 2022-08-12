using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject cubePref;
    [SerializeField] private Color[] colors;
    [SerializeField] private Color baseColor;
    [Range(1,8)]
    [SerializeField] private int level;
    [SerializeField] private int blocksPerLevel;
    [Header("Pop Up Texts")]
    [SerializeField] private GameObject popUpPref;

    [Header("Static Texts")]
    [SerializeField] TextMeshPro counterText;
    [SerializeField] TextMeshPro levelText;
    [SerializeField] TextMeshPro maxText;
    bool isMaxAmount;
    //TextController
    private Material topMaterial;
    private Material botMaterial;
    private GameObject topObject;
    private GameObject botObject;

    private CubeScaling cubeVariator;

    private int sectionsAmount;
    private int maxAmount;

    private int quantity;
    private int oldQuantity;
    [SerializeField]
    public int Quantity{
        get { return quantity; }
        set {
            oldQuantity = quantity;
            quantity = value;
            
            if (quantity < 0) quantity = 0;
            if (quantity > maxAmount) quantity = maxAmount;

            SetPop(oldQuantity, quantity);
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
        cubeVariator = new CubeScaling(sectionsAmount);
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
            cubeVariator = new CubeScaling(sectionsAmount);
        }
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
        cubeVariator.SetCubes(topObject, botObject, quantity % sectionsAmount);
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

    private void SetPop(int oldQuantity, int newQuantity){
        if(oldQuantity != newQuantity){
            GameObject popText = Instantiate(popUpPref, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
            popText.transform.localPosition = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 0.0f), -1); //SetRandPos
            popText.GetComponent<PopUpController>()
                .SetText(
                    oldQuantity < newQuantity ? $"+{newQuantity - oldQuantity}" : $"{newQuantity - oldQuantity}",   //Check for number sign
                    oldQuantity < newQuantity ? Color.green : Color.red                                             //Check for TextColor
                );
        }

    }
}

