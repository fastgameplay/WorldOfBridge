using UnityEngine;
using TMPro;

public class CubeSide : MonoBehaviour
{
    [Header("Static Texts")]
    [SerializeField] TextMeshPro counterText;
    [SerializeField] TextMeshPro levelText;
    [SerializeField] GameObject maxText;
    
    public void SetLevel(int _level){
        levelText.text = $"LVL {_level}";
    }
    public void SetLevelState(bool _state){
        if (levelText.gameObject.activeSelf != _state) levelText.gameObject.SetActive(_state);
    }
    public void SetText(string _text, Color _color){
        counterText.text = _text;
        counterText.color = _color;
    }
    public void SetMaxState(bool _state){
        if (maxText.activeSelf != _state) maxText.SetActive(_state);
    }
}
