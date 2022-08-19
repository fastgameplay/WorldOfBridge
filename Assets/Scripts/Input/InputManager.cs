using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TouchInput))]
public class InputManager : MonoBehaviour
{
    public TouchInput Input { set { input = value; } }
    private TouchInput input;
    public float HorizontalNormilized { get { return input.Horizontal / screenHalfWidth; } }
    public float VerticalNormilized { get { return input.Vertical / screenHalfHight; } }


    private int screenHalfWidth;
    private int screenHalfHight;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned InputManager", typeof(InputManager)).GetComponent<InputManager>();
                    instance.Input = instance.gameObject.AddComponent<TouchInput>();
                }
            }
            return instance;
        }
    }
    private static InputManager instance;
    private void Start(){
        screenHalfHight = Screen.height / 2;
        screenHalfWidth = Screen.width / 2;
        input = GetComponent<TouchInput>();
    }


}
