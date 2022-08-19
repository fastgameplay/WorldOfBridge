using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public bool Tap { get { return tap; } }
    public bool Hold { get { return hold; } }
    public bool DoubleTap { get { return doubleTap; } }
    public bool IsStatic { get { return isStatic; } }
    
    public float Horizontal { get { return horizontal; } }
    public float HorizontalNormilized { get { return horizontal / screenHalfWidth; } }

    public float Vertical { get { return vertical; } }
    public float VerticalNormilized { get { return vertical / screenHalfHight; } }


    private Vector2 startTouch;
    private float lastTap, horizontal, vertical;
    private int screenHalfWidth, screenHalfHight;
    private bool tap,hold, doubleTap, isStatic;

}
