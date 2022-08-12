using UnityEngine;
using TMPro;
public class PopUpController : MonoBehaviour {
    [SerializeField] private TextMeshPro textMP;

    public void SetText(string _text, Color _color){
        textMP.text = _text;
        textMP.color = _color;
    }
}
