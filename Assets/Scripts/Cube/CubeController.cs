using UnityEngine;
public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject cubePref;
    [SerializeField] private Color[] colors;
    [SerializeField] private Color baseColor;



    private Material topMaterial;
    private Material botMaterial;
    private GameObject topObject;
    private GameObject botObject;

    private CubeScaling cubeVariator;

    private int sectionsAmount;

    private int quantity;
    [SerializeField]
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

        topMaterial = topObject.GetComponent<MeshRenderer>().material;
        botMaterial = botObject.GetComponent<MeshRenderer>().material;

        topObject.transform.localPosition = Vector3.zero;
        botObject.transform.localPosition = new Vector3(0, -20, 0);
    }



    public void SetUp(int _sectionsAmount){
        sectionsAmount = _sectionsAmount;
        cubeVariator = new CubeScaling(_sectionsAmount);
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
   

}

