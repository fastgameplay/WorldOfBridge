using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TouchInput))]
public class InputManager : MonoBehaviour
{
    private TouchInput input;

    public bool Tap { get { return input.Tap; } }
    public bool DoubleTap { get { return input.DoubleTap; } }
    public bool Hold { get { return input.Hold; } }
    public bool IsStatic{ get { return input.IsStatic; } }
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
                    instance.input = instance.gameObject.AddComponent<TouchInput>();
                }
            }
            return instance;
        }
    }
    private static InputManager instance;
    private void awake(){
        screenHalfHight = Screen.height / 2;
        screenHalfWidth = Screen.width / 2;
        input = GetComponent<TouchInput>();
    }


}
