
using UnityEngine;

public class CubeText : MonoBehaviour
{
    [SerializeField] private CubeSide[] CubeSides;
    private int cubeSidesLenght;
    public void Awake(){
        cubeSidesLenght = CubeSides.Length;
    }
    public void SetLevel(int _level){
        for (int i = 0; i < cubeSidesLenght; i++){
            CubeSides[i].SetLevel(_level);
        }
    }
    public void SetLevelState(bool _State)
    {
        for (int i = 0; i < cubeSidesLenght; i++)
        {
            CubeSides[i].SetLevelState(_State);
        }
    }
    public void SetText(string _text, Color _color){
        for (int i = 0; i < cubeSidesLenght; i++){
            Debug.Log("[" + Time.time + "], " + "Text :" + _text);
            CubeSides[i].SetText(_text, _color);
        }
    }
    public void SetMaxState(bool _isActive){
        for (int i = 0; i < cubeSidesLenght; i++){
            CubeSides[i].SetMaxState(_isActive);
        }
    }
}
